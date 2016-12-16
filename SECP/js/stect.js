var $$ = function (id) {
    return document.getElementById(id);
}
window.onload = function () {
    var btnSelect = $$("btn_select");
    var curSelect =btnSelect.getElementsByTagName("span")[0];
    var oSelect = btnSelect.getElementsByTagName("select")[0];
    var aOption =btnSelect.getElementsByTagName("option");
    oSelect.onchange = function () {
        var text = oSelect.options[oSelect.selectedIndex].text;
        curSelect.innerHTML = text;
    }
}