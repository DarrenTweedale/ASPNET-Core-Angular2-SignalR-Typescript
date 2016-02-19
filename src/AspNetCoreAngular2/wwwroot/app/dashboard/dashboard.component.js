var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var common_1 = require('angular2/common');
var foodcomponent_1 = require('../food/foodcomponent');
var chatComponent_1 = require('../chat/chatComponent');
var cpuComponent_1 = require('../cpu/cpuComponent');
var DashboardComponent = (function () {
    function DashboardComponent() {
        this.message = "Hello from HomeComponent constructor";
    }
    DashboardComponent = __decorate([
        core_1.Component({
            selector: 'home',
            templateUrl: 'app/dashboard/dashboard.component.html',
            directives: [common_1.CORE_DIRECTIVES, foodcomponent_1.FoodComponent, chatComponent_1.ChatComponent, cpuComponent_1.CpuComponent]
        }), 
        __metadata('design:paramtypes', [])
    ], DashboardComponent);
    return DashboardComponent;
})();
exports.DashboardComponent = DashboardComponent;
//# sourceMappingURL=dashboard.component.js.map