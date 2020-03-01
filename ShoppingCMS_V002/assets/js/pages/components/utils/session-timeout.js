"use strict";
var KTSessionTimeoutDemo = {
        init: function () {
            $.sessionTimeout({
                title: "سشن تایم اوت", message: "سشن ورودی شما رو به منقضی شدن است لطفا دوباره در سامانه لوگین نمایید", keepAliveUrl: "./Controllers/Api/SessionMedic.aspx", redirUrl: "?p=page_user_lock_1", logoutUrl: "?p=page_user_login_1", warnAfter:
                    (10000), redirAfter: (5000), ignoreUserActivity: !0, countdownMessage: "انتقال به درگاه ورود تا {timer} ثانیه دیگر.", countdownBar: !0
                })
        }
    };
jQuery(document).ready(function () {
        KTSessionTimeoutDemo.init()
    }

);