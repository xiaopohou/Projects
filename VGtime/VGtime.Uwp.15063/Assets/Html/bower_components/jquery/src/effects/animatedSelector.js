define([
    "../core",
    "../selector",
    "../effects"
], function (jQuery) {
    "use strict";
    jQuery.expr.pseudos.animated = function (elem) {
        return jQuery.grep(jQuery.timers, function (fn) {
            return elem === fn.elem;
        }).length;
    };
});
//# sourceMappingURL=animatedSelector.js.map 
//# sourceMappingURL=animatedSelector.js.map