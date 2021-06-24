﻿setTimeout(SetHref, 1000);

function SetHref() {
    document.querySelector(".topbar-wrapper a")
            .setAttribute("href", "/Home/Index/");
}