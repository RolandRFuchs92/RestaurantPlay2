var CustomScripts = {
    baseImage: "",

    GetBase64String: function (file) {
        var reader = new FileReader();
        reader.onload = function() {
            CustomScripts.baseImg = reader.result;
        };
        reader.readAsDataURL(file);
    },

    ImgChange : function () {
        var file = $('input[type=file]')[0].files[0];
        CustomScripts.GetBase64String(file);
    },

    GetImageJson: function() {
        var imageDetail = {};
        var file = $('input[type=file]')[0].files[0];
        
        imageDetail[0] = {
            name: "ImageName",
            value: file.name 
        };
        imageDetail[1] = {
            name: "ImageBase",
            value: CustomScripts.baseImg
        };

        return imageDetail;
    }
}

