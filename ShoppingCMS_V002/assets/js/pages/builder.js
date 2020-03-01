"use strict";
var KTLayoutBuilder = function () {
    var e = {
        init: function () {
            $("#kt-btn-howto").click(function (e) {
                e.preventDefault(), $("#kt-howto").slideToggle()
            })
        },
        startLoad: function (e) {
            $("#builder_export").addClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").find("span").text("Exporting...").closest(".kt-form__actions").find(".btn").attr("disabled", !0), toastr.info(e.title, e.message)
        },
        doneLoad: function () {
            $("#builder_export").removeClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").find("span").text("Export").closest(".kt-form__actions").find(".btn").attr("disabled", !1)
        },
        exportHtml: function (t) {
            e.startLoad({
                title: "Generate HTML Partials",
                message: "Process started and it may take about 1 to 10 minutes."
            }), $.ajax("index.php", {
                method: "POST",
                data: {
                    builder_export: 1,
                    export_type: "partial",
                    demo: t,
                    theme: "metronic"
                }
            }).done(function (t) {
                var a = JSON.parse(t);
                if (a.message) e.stopWithNotify(a.message);
                else var i = setInterval(function () {
                    $.ajax("index.php", {
                        method: "POST",
                        data: {
                            builder_export: 1,
                            builder_check: a.id
                        }
                    }).done(function (t) {
                        var a = JSON.parse(t);
                        void 0 !== a && 1 === a.export_status && $("<iframe/>").attr({
                            src: "index.php?builder_export&builder_download&id=" + a.id,
                            style: "visibility:hidden;display:none"
                        }).ready(function () {
                            toastr.success("Export HTML Version Layout", "HTML version exported."), e.doneLoad(), clearInterval(i)
                        }).appendTo("body")
                    })
                }, 15e3)
            })
        },
        exportHtmlStatic: function (t) {
            e.startLoad({
                title: "Generate HTML Static Version",
                message: "Process started and it may take about 1 to 10 minutes."
            }), $.ajax("index.php", {
                method: "POST",
                data: {
                    builder_export: 1,
                    export_type: "html",
                    demo: t,
                    theme: "metronic"
                }
            }).done(function (t) {
                var a = JSON.parse(t);
                if (a.message) e.stopWithNotify(a.message);
                else var i = setInterval(function () {
                    $.ajax("index.php", {
                        method: "POST",
                        data: {
                            builder_export: 1,
                            builder_check: a.id
                        }
                    }).done(function (t) {
                        var a = JSON.parse(t);
                        void 0 !== a && 1 === a.export_status && $("<iframe/>").attr({
                            src: "index.php?builder_export&builder_download&id=" + a.id,
                            style: "visibility:hidden;display:none"
                        }).ready(function () {
                            toastr.success("Export Default Version", "Default HTML version exported with current configured layout."), e.doneLoad(), clearInterval(i)
                        }).appendTo("body")
                    })
                }, 15e3)
            })
        },
        stopWithNotify: function (t, a) {
            a = a || "danger", void 0 !== toastr[a] && toastr[a]("Verification failed", t), e.doneLoad()
        },
        runGenerate: function () {
            $.ajax("../tools/builder/cron-generate.php", {
                method: "POST",
                data: {
                    theme: "metronic"
                }
            }).done(function (e) { })
        }
    },
        t = {
            reCaptchaVerified: function () {
                return $.ajax("../tools/builder/recaptcha.php?recaptcha", {
                    method: "POST",
                    data: {
                        response: $("#g-recaptcha-response").val()
                    }
                }).fail(function () {
                    grecaptcha.reset(), $("#alert-message").removeClass("alert-success kt-hide").addClass("alert-danger").html("Invalid reCaptcha validation")
                })
            },
            init: function () {
                var a;
                $("#builder_export").click(function (e) {
                    e.preventDefault(), a = $(this), $("#kt-modal-purchase").modal("show"), $("#alert-message").addClass("kt-hide"), grecaptcha.reset()
                }), $("#submit-verify").click(function (i) {
                    i.preventDefault(), $("#g-recaptcha-response").val() ? t.reCaptchaVerified().done(function (t) {
                        if (t.success) {
                            $('[data-dismiss="modal"]').trigger("click");
                            var i = $(a).data("demo");
                            switch ($(a).attr("id")) {
                                case "builder_export":
                                case "builder_export_html":
                                    e.exportHtml(i);
                                    break;
                                case "builder_export_html_static":
                                    e.exportHtmlStatic(i)
                            }
                        } else grecaptcha.reset(), $("#alert-message").removeClass("alert-success kt-hide").addClass("alert-danger").html("Invalid reCaptcha validation")
                    }) : $("#alert-message").removeClass("alert-success kt-hide").addClass("alert-danger").html("Invalid reCaptcha validation")
                })
            }
        },
        a = function () {
            e.init(), $('[href^="#kt_builder_"]').click(function (e) {
                var t = $(this).attr("href"),
                    a = $('[name="builder_submit"]'),
                    i = $('[name="builder[tab]"]');
                0 === $(i).length ? $("<input/>").attr("type", "hidden").attr("name", "builder[tab]").val(t).insertBefore(a) : $(i).val(t)
            }).each(function () {
                if ($(this).hasClass("active")) {
                    var e = $(this).attr("href"),
                        t = $('[name="builder_submit"]'),
                        a = $('[name="builder[tab]"]');
                    0 === $(a).length ? $("<input/>").attr("type", "hidden").attr("name", "builder[tab]").val(e).insertBefore(t) : $(a).val(e)
                }
            }), $('[name="builder_submit"]').click(function (e) {
                e.preventDefault();
                var t = $(this);
                $(t).addClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").closest(".kt-form__actions").find(".btn").attr("disabled", !0), $.ajax("index.php?demo=" + $(t).data("demo"), {
                    method: "POST",
                    data: $("[name]").serialize()
                }).done(function (e) {
                    toastr.success("Preview updated", "Preview has been updated with current configured layout.")
                }).always(function () {
                    setTimeout(function () {
                        location.reload()
                    }, 600)
                })
            }), $('[name="builder_reset"]').click(function (e) {
                e.preventDefault();
                var t = $(this);
                $(t).addClass("kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light").closest(".kt-form__actions").find(".btn").attr("disabled", !0), $.ajax("index.php?demo=" + $(t).data("demo"), {
                    method: "POST",
                    data: {
                        builder_reset: 1,
                        demo: $(t).data("demo")
                    }
                }).done(function (e) { }).always(function () {
                    location.reload()
                })
            })
        };
    return {
        init: function () {
            t.init(), a()
        }
    }
}();
jQuery(document).ready(function () {
    KTLayoutBuilder.init()
});