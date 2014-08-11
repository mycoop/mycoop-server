//
App.Router = (function () {
    "use strict";

    // using

    // static

    var app = App.current;
    var config = App.config;

    // private

    // public

    function go(urls, callback) {

        var self = this;
        var publ = this.publ;
        if (urls && urls[0] && self.routes[urls[0]]) {

            var roles = config.getRoles(self.frameConfig, urls[0]);

            if (!roles || app.context.hasRole(roles)) {
                self.routes[urls[0]]({ urls: urls.slice(1), callback: callback });
            }
        }
    }

    function add(url, action) {
        var self = this;
        var publ = this.publ;
        self.routes[url] = action;
        self.indexRoutes.push(url);
    }

    function first() {
        var self = this;
        var publ = this.publ;
        for (var i = 0; i < self.indexRoutes.length; i++) {
            var roles = config.getRoles(self.frameConfig, self.indexRoutes[i]);
            if (!roles || app.context.hasRole(roles)) {
                return self.indexRoutes[i];
            }
        }
    }

    // consructor

    function consructor(spec) {

        spec = spec || {};

        var self = {
            frameConfig: spec.frameConfig,
            routes: {},
            indexRoutes: []
        };


        self.publ = {
            go: go.bind(self),
            add: add.bind(self),
            first: first.bind(self),
        };

        return self.publ;
    }

    return consructor;

})();
