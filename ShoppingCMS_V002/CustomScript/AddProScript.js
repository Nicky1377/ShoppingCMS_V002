

function ChangeAllInput(pg) {
    //$(itm).attr("id")

    // alert("id : " + );
    //alert("onChange"+pg);
    var ee = fillJson(pg);
    //alert(pg);
    Enc(ee);

}

//////cookie actions begin
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}


function deleteCookie(cname) {
    document.cookie = cname + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
}
//////cookie actions end
function Enc(str) {
    PostJson = {
        'json': str
    };
    var res = "";
    $.ajax({
        url: '/Product/EncJson',
        type: "post",
        data: JSON.stringify(PostJson),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            res = response;

            setCookie("AddProCookie", res, 30);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus);

        }
    });
    return res;
}

function Des(str) {

    PostJson = {
        'json': str
    };

    $.ajax({
        url: '/Product/DecJson',
        type: "post",
        data: JSON.stringify(PostJson),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var res = response;
           alert(res);
            // alert(res.Page);
            fillItms(res);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus);
            return "";
        }
    });
}

function fillJson(pg) {

    //  alert(pg);
    var CookieString = "";

    if (pg == '1') {
        var Title = $('#Title_p1').val();
        var Description = $('#Description_p1').val();
        var SEO_keyword = $('#SEO_keyword_p1').val();
        var SEO_description = $('#SEO_description_p1').val();
        var SearchGravity = $('#SearchGravity_p1').val();
        var IsAd = $('#IsAd_p1').val();
        var pics = $('#Pics_p1').val();

        //alert(pg);
        CookieString =
            '{"Page":"' + pg +
            '","Title":"' + Title +
            '","Description":"' + Description +
            '","SEO_keyword":"' + SEO_keyword +
            '","SEO_description":"' + SEO_description +
            '","SearchGravity":"' + SearchGravity +
            '","IsAd":"' + IsAd +
            '","pics":"' + pics + '"}';

        //alert(CookieString);
    }
    else if (pg == '2') {
        var Title = $('#Title_p1').val();
        var Description = $('#Description_p1').val();
        var SEO_keyword = $('#SEO_keyword_p1').val();
        var SEO_description = $('#SEO_description_p1').val();
        var SearchGravity = $('#SearchGravity_p1').val();
        var IsAd = $('#IsAd_p1').val();
        var pics = $('#Pics_p1').val();
        //------------
        var Type = $("#Select2_A option:selected").val();
        var Main = $("#Select2_B option:selected").val();
        var id = $("#Mpro_").text();
        var Sub = $("#Select2_C option:selected").val();
        var SubKey = $("#kt_select2_multiple").val();
        var url2 = $('#Url_2').text();
        CookieString =
            '{"Page":"' + pg +
            '","Title":"' + Title +
            '","Description":"' + Description +
            '","SEO_keyword":"' + SEO_keyword +
            '","SEO_description":"' + SEO_description +
            '","SearchGravity":"' + SearchGravity +
            '","IsAd":"' + IsAd +
            '","pics":"' + pics +
            '","url2":"' + url2 +
            '","Type":"' + Type +
            '","Main":"' + Main +
            '","id":"' + id +
            '","Sub":"' + Sub +
            '","SubKey":"' + SubKey + '"}';
    }
    else if (pg == '3') {

        var Title = $('#Title_p1').val();
        var Description = $('#Description_p1').val();
        var SEO_keyword = $('#SEO_keyword_p1').val();
        var SEO_description = $('#SEO_description_p1').val();
        var SearchGravity = $('#SearchGravity_p1').val();
        var IsAd = $('#IsAd_p1').val();
        var pics = $('#Pics_p1').val();
        //------------
        var Type = $("#Select2_A option:selected").val();
        var Main = $("#Select2_B option:selected").val();
        var id = $("#Mpro_").text();
        var Sub = $("#Select2_C option:selected").val();
        var SubKey = $("#kt_select2_multiple").val();
        var url2 = $('#Url_2').text();
        //--------------------
        var json = "";
        var otArr = [];
        $('.tshpSelect23').each(function (e, obj) {
            var idSelected = obj.id.replace("tshpSelect2-", "");
            var ids = $('#tshpSelect2-' + idSelected).val();

            otArr.push('"Mainid_' + idSelected + '":"' + ids + '"');
        });

        json += otArr.join(",");
       // alert(json);
        var url3 = $('#Url_3').text();
        var OptionTbl_3 = $('#OptionTbl_3').text();
        //------------------------

        CookieString =
            '{"Page":"' + pg +
            '","Title":"' + Title +
            '","Description":"' + Description +
            '","SEO_keyword":"' + SEO_keyword +
            '","SEO_description":"' + SEO_description +
            '","SearchGravity":"' + SearchGravity +
            '","IsAd":"' + IsAd +
            '","pics":"' + pics +
            '","Type":"' + Type +
            '","url2":"' + url2 +
            '","Main":"' + Main +
            '","id":"' + id +
            '","Sub":"' + Sub +
            '","SubKey":"' + SubKey +
            '","url3":"' + url3 +
            '","OptionTbl_3":"' + OptionTbl_3 +
            //'",' + json +
            '"}';
    }
    else if (pg == '4') {

        var Title = $('#Title_p1').val();
        var Description = $('#Description_p1').val();
        var SEO_keyword = $('#SEO_keyword_p1').val();
        var SEO_description = $('#SEO_description_p1').val();
        var SearchGravity = $('#SearchGravity_p1').val();
        var IsAd = $('#IsAd_p1').val();
        var pics = $('#Pics_p1').val();
        //------------
        var Type = $("#Select2_A option:selected").val();
        var Main = $("#Select2_B option:selected").val();
        var id = $("#Mpro_").text();
        var Sub = $("#Select2_C option:selected").val();
        var SubKey = $("#kt_select2_multiple").val();
        var url2 = $('#Url_2').text();
        //--------------------
        var json = "";
        var otArr = [];
        $('.tshpSelect23').each(function (e, obj) {
            var idSelected = obj.id.replace("tshpSelect2-", "");
            var ids = $('#tshpSelect2-' + idSelected).val();

            otArr.push('"Mainid_' + idSelected + '":"' + ids + '"');
        });

        json += otArr.join(",");
        var url3 = $('#Url_3').text();
        var OptionTbl_3 = $('#OptionTbl_3').text();
        //------------------------
        var param = '0';
        //var id_MProduct = $("#Mpro_").text();
        //var Quantity = $("#VahedID-" + param).val().split("_")[0].replace(/,/g, "");
        //var QuantityModule = $("#SelectVahedQuntID-" + param + " option:selected").val();
        //var PricePerquantity = $("#inpPrice-" + param).val().split("_")[0].replace(/,/g, "");
        //var PriceOff = $("#totalPrice-" + param).val();
        //var offTypeValue = $("#inpOffPrice-" + param).val().split("_")[0].replace(/,/g, "");
        //var OffType = $("#SelectOffID-" + param + " option:selected").val();
        //var id_MainStarTag = $("#MainTagID-" + param + " option:selected").val();
        //var PriceModule = $("#SelectVahedPriceID-" + param + " option:selected").val();
        //var PriceShow = $("#SelectShowPriceID-" + param + " option:selected").val();
        //var tgs = $("#SelectTagsID-" + param).val();
        var url4 = $('#Url_4').text();
        //--------------------------

        CookieString =
            '{"Page":"' + pg +
            '","Title":"' + Title +
            '","Description":"' + Description +
            '","SEO_keyword":"' + SEO_keyword +
            '","SEO_description":"' + SEO_description +
            '","SearchGravity":"' + SearchGravity +
            '","IsAd":"' + IsAd +
            '","pics":"' + pics +
            '","Type":"' + Type +
            '","url2":"' + url2 +
            '","Main":"' + Main +
            '","id":"' + id +
            '","Sub":"' + Sub +
            '","SubKey":"' + SubKey +
            '","url3":"' + url3 +
            '","OptionTbl_3":"' + OptionTbl_3 +
            '",' + json + ',' +
            //'","id_MProduct":"' + id_MProduct +
            //'","Quantity":"' + Quantity +
            //'","QuantityModule":"' + QuantityModule +
            //'","PricePerquantity":"' + PricePerquantity +
            //'","PriceOff":"' + PriceOff +
            //'","offTypeValue":"' + offTypeValue +
            //'","OffType":"' + OffType +
            //'","id_MainStarTag":"' + id_MainStarTag +
            //'","PriceModule":"' + PriceModule +
            //'","PriceShow":"' + PriceShow +
            '"url4":"' + url4 +
            //'","tgs":' + tgs +
            '"}';
    }
    return CookieString;
}

function FreezItmsP1() {
    $('#Title_p1').prop("disabled", true);
    $('#Description_p1').prop("disabled", true);
    $('#SEO_keyword_p1').prop("disabled", true);
    $('#SEO_description_p1').prop("disabled", true);
    $('#SearchGravity_p1').prop("disabled", true);
    $('#IsAd_p1').prop("disabled", true);
    $('#picss').prop("disabled", true);
    $("#Sub_btn1").hide(200);
    $("#Sub_btn12").hide(200);
    $("#btn_next").show(200);
    $("#EditBtnP1").show(200);
}

function FreezItmsP2() {
    $("#Select2_A").prop("disabled", true);
    $("#Select2_B").prop("disabled", true);
    $("#Select2_C").prop("disabled", true);
    $("#kt_select2_multiple").prop("disabled", true);
    $("#Sub_btn2").hide(200);
    $("#EditBtnP2").show(200);
    
}

function FreezItmsP3() {
    $('.tshpSelect23').each(function (e, obj) {
        var idSelected = obj.id.replace("tshpSelect2-", "");
        $('#tshpSelect2-' + idSelected).prop("disabled", true);
    });

    $('#NewClkSub').prop("disabled", true);
    $('#Add_Key').prop("disabled", true);
    $('#Add_Value').prop("disabled", true);
    $("#Sub_btn3").hide(200);
    $("#EditBtnP3").show(200);
}

function fillItms(json) {
    var mod = JSON.parse(json);
    if (mod.Page == '1') {
        Page1Filler(json);


    } else if (mod.Page == '2') {

        $('#Url_2').text(mod.url2);
        $('#step2').load(mod.url2, function (response, status, xhr) {
            console.log("status = " + status);
            //Page2Filler(json);
        });
        Page1Filler(json);
        FreezItmsP1();
        //-----------p1

        

    } else if (mod.Page == '3') {
        
        Page1Filler(json);
        FreezItmsP1();
        //-----------p1
        $('#Url_2').text(mod.url2);
        $('#step2').load(mod.url2, function (response, status, xhr) {
            console.log("status2 = " + status);
            Page2Filler(json);
            setTimeout(function () { FreezItmsP2(); }, 2000);
            $('#Url_3').text(mod.url3);
        });
        ////-----------p2
        
       
        //alert(mod.url3);
        $('#step3').load(mod.url3, function (response, status, xhr) {
            console.log("status3 = " + status);
            Page3Filler(json);
        });
    }
    else if (mod.Page == '4') {
        Page1Filler(json);
        FreezItmsP1();
        //-----------p1
        $('#Url_2').text(mod.url2);
        $('#step2').load(mod.url2, function (response, status, xhr) {
            console.log("status2 = " + status);
            Page2Filler(json);
            setTimeout(function () { FreezItmsP2(); }, 1000);
            $('#Url_3').text(mod.url3);

        });
        //-----------p2
        $('#step3').load(mod.url3, function (response, status, xhr) {
            console.log("status3 = " + status);
            Page3Filler(json);
            $('#Url_4').text(mod.url4);
            FreezItmsP3();
        });
        //------------p3
        $('#step4').load(mod.url4, function (response, status, xhr) {
            console.log("status4 = " + status);
        });
    }


}

function Page1Filler(json) {
    var mod = JSON.parse(json);

    $('#Title_p1').val(mod.Title);
    $('#Description_p1').val(mod.Description);
    $('#SEO_keyword_p1').val(mod.SEO_keyword);
    $('#SEO_description_p1').val(mod.SEO_description);
    $('#SearchGravity_p1').val(mod.SearchGravity);
    var ad = mod.IsAd;
    if (ad == "on") {
        $('#IsAd_p1').prop("checked", true);
    } else {
        $('#IsAd_p1').prop("checked", false);
    }
    $('#Pics_p1').val(mod.pics);
    $("#Mpro_").text(mod.id);
}

function Page2Filler(json) {
    var mod = JSON.parse(json);
    $("#Mpro_").text(mod.id);
    if (mod.Type != '0') {
        
        $('#Select2_A').val(mod.Type);
        console.log(mod.Type);
        $('#Select2_A option[value=' + mod.Type + ']').prop("selected", true);
            $('#Select2_B').prop("disabled", false);
            $.ajax({
                url: "/Product/DropListFiller",
                type: "post",
                data: { "drop": "MainCat", "id": mod.Type },
                success: function (response) {
                    
                    console.log("s1 : " + response);
                    var token = response;
                    var s = "<option value=0 selected >انتخاب کنید</option>";
                    for (var i = 0; i < token.length; i++) {
                        s += "<option value=" + token[i].Id + ">" + token[i].Value + "</option>";
                    }

                    $('#Select2_B').html(s);

                    if (mod.Main != '0') {
                       
                        $('#Select2_B option[value=' + mod.Main + ']').prop("selected", true);

                        //////////fill Sub
                        $('#Select2_C').prop("disabled", false);
                        $.ajax({
                            url: "/Product/DropListFiller",
                            type: "post",
                            data: { "drop": "SubCat", "id": $("#Select2_B option:selected").val() },
                            success: function (response) {
                                console.log("res1 = " + response);
                                var token = response;
                                var s = "<option value=0 selected>انتخاب کنید</option>";
                                for (var i = 0; i < token.length; i++) {
                                    s += "<option value=" + token[i].Id + ">" + token[i].Value + "</option>";
                                }

                                $('#Select2_C').html(s);

                                if (mod.Sub != '0') {
                                    $('#Select2_C option[value=' + mod.Sub + ']').prop("selected", true);
                                    console.log("res 2 req id =" + $("#Select2_C option:selected").val());
                                    //////////fill subkey
                                    $('#kt_select2_multiple').prop("disabled", false);
                                    $.ajax({
                                        url: "/Product/DropListFiller",
                                        type: "post",
                                        data: { "drop": "SubCat_Key", "id": $("#Select2_C option:selected").val() },
                                        success: function (response) {
                                            console.log("res2 = " + response);
                                            var token = response;
                                            var s = '<option value=0 selected disabled hidden style="display: none"></option>';
                                            s += "<optgroup label=" + $("#Select2_C option:selected").text() + ">";

                                            var m_m = mod.SubKey.split(',');

                                            for (var i = 0; i < token.length; i++) {

                                                if (m_m.indexOf(token[i].Id.toString()) != -1) {

                                                    s += "<option value=" + token[i].Id + " selected>" + token[i].Value + "</option>";
                                                } else {
                                                    s += "<option value=" + token[i].Id + ">" + token[i].Value + "</option>";
                                                }
                                            }
                                            s += "</optgroup>"
                                            
                                            $('#kt_select2_multiple').html(s);
                                            $('#kt_select2_multiple option[value = 0 ]').prop("selected", false);

                                            

                                        },
                                        error: function (jqXHR, textStatus, errorThrown) {
                                            console.log(textStatus, errorThrown);
                                        }
                                    });

                                    /////////////
                                }
                            },
                            error: function (jqXHR, textStatus, errorThrown) {
                                console.log(textStatus, errorThrown);
                            }
                        });
                        /////////////
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(textStatus, errorThrown);
                }
            });
        
        /////////////fill Main

    }


}

function Page3Filler(json) {
    var mod = JSON.parse(json);
   
    $('.tshpSelect23').each(function (e, obj) {
        var idSelected = obj.id.replace("tshpSelect2-", "");
        var ids = mod['Mainid_' + idSelected].split(',');
        for (var i = 0; i < ids.length; i++) {
            $('#tshpSelect2-' + idSelected + ' option[value = ' + ids[i] + ']').prop("selected", true);
        }
        $('#tshpSelect2-' + idSelected + ' option[value = 0 ]').prop("selected", false);

    });
}