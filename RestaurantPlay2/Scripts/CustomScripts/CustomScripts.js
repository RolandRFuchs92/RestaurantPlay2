var Config = [
		{
				replace : "#ImageCardList",
				url : "/ImageItems/ImageCard/SaveImageCard"
		},
		{
				replace: ".container.body-content",
				url: "/ImageItems/ImageCarousel/SaveCarousel"
		}
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

				$.post(Config[cardRefId].url,
						formData,
						function (data) {
								$(Config[cardRefId].replace).html(data);
								$('form')[0].reset();
								$('form .id').val('0');
								toastr['success']('Your new card has been saved!', 'Success!');
						}).fail(function (data) {
						toastr['error']('We were unable to save the image error!', 'Error!');
				});
		},

		SyncChangeToElement: function (event, toElement) {
				var self = $(event.currentTarget);
				$(toElement).html(self.val());
		},

		SycnImageToElement: function (event, toElement) {
				var self = $(event.currentTarget)[0];
				var file = self.files[0];
				var toEl = $(toElement);

				var reader = new FileReader();
				reader.onload = function (e) {
						toEl.attr('src', e.target.result);
				}
				reader.readAsDataURL(file);

		}

}

