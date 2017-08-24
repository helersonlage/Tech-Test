function getPackage() {

    var imputData = getImputData();
    getPkgAjax(imputData);

}

function getImputData() {
    var PackageImput =
        {
            'lenght': 0,
            'breadth': 0,
            'height': 0,
            'weight': 0.00
        }

    PackageImput.lenght = parseInt($('#Length').val());
    PackageImput.breadth = parseInt($('#Breadth').val());
    PackageImput.height = parseInt($('#Height').val());
    PackageImput.weight = parseFloat($('#Weight').val());

    return PackageImput;
}

function getPkgAjax(data) {   
    $.ajax({
        type: "POST",
        url: '../api/Package/GetPackage',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
    }).done(function (data) {        
        var ret = JSON.parse(data)
        if (ret.Name == null) {
            $('#msgs').html("<div class='alert alert-danger'> Package size not found. Incorrect  dimensions or weight." + " " + "</div>");
        } else {
            $('#msgs').html("<div class='alert alert-success'> Package size: " + ret.Name + ".Cost is: $" + ret.Cost + "</div>");
        }
     
    }).fail();

}