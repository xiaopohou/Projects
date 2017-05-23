﻿/// <reference path="../typings/jquery.d.ts"/>
/// <reference path="../typings/hammerjs.d.ts"/>
/// <reference path="../typings/winrt.d.ts"/>

function scrollToTop(): void {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}