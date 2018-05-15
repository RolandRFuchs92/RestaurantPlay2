var urlRef = [
    "/ImageItems/ImageCard/SaveImageCard",
    "/ImageItems/ImageCarousel/SaveCarousel"
]

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
    },

    SubmitImageBasedForm: function(e, cardRefId) {
        e.preventDefault;

        if (!$('form').valid())
            return;

        var formData = $('#form0').serializeArray();
        var img = CustomScripts.GetImageJson();
        formData.push(img[0]);
        formData.push(img[1]);

        $.post(urlRef[cardRefId],
            formData,
            function (data) {
                $('#ImageCardList').html(data);
                $('form')[0].reset();
                $('form .id').val('0');
                toastr['success']('Your new card has been saved!', 'Success!');
            }).fail(function (data) {
            toastr['error']('We were unable to save the image error!', 'Error!');
        });
    }
}

