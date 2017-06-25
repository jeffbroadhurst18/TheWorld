(function () {

    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $dd = $("#sidebar");

    // toggleclass adds or removes a class
    $("#sidebarToggle").on("click", function () {
        var $icon = $("#sidebarToggle i.fa");
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        }
        else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        }
    })

    //var ele = $("#username");
    //ele.text = "Shawn Wildemuth";

    //var main = $("#main");

    //main.on("mouseenter", function () {
    //    main.style.backgroundColor = "#888";
    //});

    //main.on("mouseleave", function () {
    //    main.style.backgroundColor = "";
    //});

    //var menuItems = $("ul.menu li a");

})();