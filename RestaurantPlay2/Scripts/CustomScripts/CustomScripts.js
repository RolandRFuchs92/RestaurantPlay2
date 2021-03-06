﻿var Config = [
	{
		replace: "#ImageCardList",
		url: "/ImageItems/ImageCard/SaveImageCard"
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
		reader.onload = function () {
			CustomScripts.baseImage = reader.result;
		};
		reader.readAsDataURL(file);
	},

	ImgChange: function () {
		var file = $('input[type=file]')[0].files[0];
		CustomScripts.GetBase64String(file);
	},

	GetImageJson: function () {
		var imageDetail = {};
		var file = $('input[type=file]')[0].files[0];

		imageDetail[0] = {
			name: "ImageName",
			value: file.name
		};
		imageDetail[1] = {
			name: "ImageBase",
			value: CustomScripts.baseImage
		};
		return imageDetail;
	},

	SubmitImageBasedForm: function (e, cardRefId) {
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
			CustomScripts.baseImage = reader.result;
			toEl.attr('src', e.target.result);
		}
		reader.readAsDataURL(file);
	},

	AjaxSubmit: function (urlLink, formData) {
		$.ajax({
			url: urlLink,
			type: "POST",
			data: formData,
			dataType: 'json',
			success: function (data) {
				debugger;
				window.location.replace("/Blogger/Blogger/Blog?blogId=" + data.Id);
				toastr['success'](data.Message);
			},
			error: function (data) {
				toastr['error'](data.Message);

			}
		});
	},

	ToastrWrapper: function (message, heading, success) {
		if (success)
			toastr['success'](Message, heading);
		else
			toastr['error'](Message, heading);
	},

	EditBlog: function (blogId) {
		var url = "/Blogger/Blogger/EditBlog";
		var inputData = { "blogId": blogId };

		$.post(url,
			inputData,
			function (data) {
				debugger;
				// TODO Do something with the data returned..
			}).fail(function (data) {
				toastr['error'](data.message, "Error!");
			});
	},

	DeleteBlog: function (event, blogId) {
		var url = "/Blogger/Blogger/DeleteBlog";
		var inputData = { "blogId": blogId };
		var refObj = $(event.currentTarget);

		bootbox.confirm("Are you sure you want to delete this blog?", YesDeleteBlog);

		function YesDeleteBlog(result) {
			if (result)
				$.post(url,
					inputData,
					function (data) {
						refObj.parents('div.col-sm-3').remove();
						toastr["success"](data.message, "Success!");
					}).fail(function () {
						return CustomScripts.errorMessage();
					});
		}
	},

	get: function (event, callback) {
		var url = $(event.currentTarget).parents('form').attr('action');
		var formData = $(event.currentTarget).parents('form').serialize();

		$.get(url,
			formData,
			function (data) {
				callback(data);
			});
	},

	post: function (event, callback) {
		var form = $(event.currentTarget).parents('form');
		var formData = form.serialize();
		var url = form.attr('action');

		$.post(url,
			formData,
			function (data) {
				if(typeof callback !== 'undefined')
					callback(data);

				form[0].reset();
				return true;
			}).fail(function () {
				return CustomScripts.errorMessage();
			});
	},

	cellPost: function (url, jsonObj, callback) {
		$.post(url,
			jsonObj,
			function (data) {
				if (typeof callback !== 'undefined')
					callback(data);

				toastr["success"]("Reccord Updated!");
			}).fail(function (data) {
				return CustomScripts.errorMessage();
			});
	},

	errorMessage: function () {
		toastr['error']("oops, there seems to have been an error!", 'Error!');
		return false;
	}
}
