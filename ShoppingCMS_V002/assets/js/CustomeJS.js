"use strict";
(function () {
    setInterval(function () {
        try {
            $("#kir2").innerText = localStorage.getItem('kiriKey');
            console.log(localStorage.getItem('kiriKey'));
        } catch (err) {
            console.log(err);
        }


    }, 200);
})();

function onkir() {
    localStorage.setItem('kiriKey', $("#inpkir").val());
    console.log(localStorage.getItem('kiriKey'));
}