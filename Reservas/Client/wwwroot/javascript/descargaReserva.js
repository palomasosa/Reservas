function Descarga()
{
    $(".hideWhenPrint").hide();
    alert("Se está por realizar un print");
    window.print();
    $(".hideWhenPrint").show();
}