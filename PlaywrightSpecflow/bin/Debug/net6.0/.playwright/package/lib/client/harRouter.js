"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.HarRouter = void 0;
var _debugLogger = require("../common/debugLogger");
/**
 * Copyright (c) Microsoft Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

class HarRouter {
  static async create(localUtils, file, notFoundAction) {
    const {
      harId,
      error
    } = await localUtils._channel.harOpen({
      file
    });
    if (error) throw new Error(error);
    return new HarRouter(localUtils, harId, notFoundAction);
  }
  constructor(localUtils, harId, notFoundAction) {
    this._localUtils = void 0;
    this._harId = void 0;
    this._notFoundAction = void 0;
    this._localUtils = localUtils;
    this._harId = harId;
    this._notFoundAction = notFoundAction;
  }
  async handleRoute(route) {
    const request = route.request();
    const response = await this._localUtils._channel.harLookup({
      harId: this._harId,
      url: request.url(),
      method: request.method(),
      headers: await request.headersArray(),
      postData: request.postDataBuffer() || undefined,
      isNavigationRequest: request.isNavigationRequest()
    });
    if (response.action === 'redirect') {
      _debugLogger.debugLogger.log('api', `HAR: ${route.request().url()} redirected to ${response.redirectURL}`);
      await route._redirectNavigationRequest(response.redirectURL);
      return;
    }
    if (response.action === 'fulfill') {
      await route.fulfill({
        status: response.status,
        headers: Object.fromEntries(response.headers.map(h => [h.name, h.value])),
        body: response.body
      });
      return;
    }
    if (response.action === 'error') _debugLogger.debugLogger.log('api', 'HAR: ' + response.message);
    // Report the error, but fall through to the default handler.

    if (this._notFoundAction === 'abort') {
      await route.abort();
      return;
    }
    await route.fallback();
  }
  dispose() {
    this._localUtils._channel.harClose({
      harId: this._harId
    }).catch(() => {});
  }
}
exports.HarRouter = HarRouter;