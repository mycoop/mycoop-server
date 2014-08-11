//
App.ViewModels.MainPageModel = (function () {
    "use strict";

    // using


    // static

    var app = App.current;
    var config = App.config;


    // private

    
    // public

    function showInfo(text, isError) {
        var self = this;
        var publ = this.publ;

        text = text || isError ? "Sorry..." : "Well done";

        publ.infoStatus(isError ? "alert-error" : "alert-success");
        publ.infoMessage(text);
        publ.infoVisible(true);
        self.infoTimer = setTimeout(publ.closeInfo, 5000);
    }

    function closeInfo() {
        var self = this;
        var publ = this.publ;

        publ.infoVisible(false);
        clearTimeout(self.infoTimer);
    }

    function show(callback) {
        var self = this;
        var publ = this.publ;

        app.body("mainPage.html", callback, publ);
    }

    function navigate(url) {

        var self = this;
        var publ = this.publ;


        publ.show();
    }
    
    function go() {
        
        var self = this;
        var publ = this.publ;

        var body = publ.httpBody();
        var data = body ? JSON.parse(body) : null;

        $.ajax(publ.url(), {
            type: publ.selectedMethod().value,
            data: data,
            success: function (model) {
                publ.result(JSON.stringify(model));
                app.showSuccess();
            },
            error: function (e) {
                publ.result(JSON.stringify(e));
                app.showError();
            }
        });
        
    }

    // consructor

    function mainPageModel() {

        var self = {
            infoTimer: null
        };

        var publ = self.publ = {};

        publ.infoMessage = ko.observable("");
        publ.infoVisible = ko.observable(false);
        publ.infoStatus = ko.observable("");
        publ.show = show.bind(self);
        publ.navigate = navigate.bind(self);
        publ.closeInfo = closeInfo.bind(self);
        publ.showInfo = showInfo.bind(self);
        
        publ.url = ko.observable(config.apiPrefix);
        publ.httpBody = ko.observable("");
        publ.result = ko.observable("");
        
        var methods = [{ name: "GET", value: "GET" },
                   { name: "POST", value: "POST" },
                   { name: "DELETE", value: "DELETE" }];

        publ.methods = ko.observable(methods);
        publ.selectedMethod = ko.observable(methods[0]);
        publ.go = go.bind(self);
        

        var templates = [
            {
                name: "sign/in",
                url: config.apiPrefix + "sign/in",
                method: methods[1],
                body: '{"email":"mr.gusev.k@gmail.com", "password": "123"}'
            },
            {
                name: "sign/out",
                url: config.apiPrefix + "sign/out",
                method: methods[1],
                body: ""
            }];

        publ.templates = ko.observable(templates);
        publ.selectedTemplate = ko.observable();
        
        publ.selectedTemplate.subscribe(function (value) {
            publ.selectedMethod(value.method);
            publ.url(value.url);
            publ.httpBody(value.body);
        });

        return publ;
    }

    return mainPageModel;

})();
