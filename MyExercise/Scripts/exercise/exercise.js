function OnSuccess(data) {
    if (data.result == "OK") {
        $("#myModal").modal("hide");
        window.location.href = "/Exercise/Index" ;
    }
}

$("#searchform").submit(function (event) {
    event.preventDefault(); //prevent default action 
    var post_url = $(this).attr("action"); //get form action url
    var request_method = $(this).attr("method"); //get form GET/POST method
    var form_data = $(this).serialize(); //Encode form elements for submission

    $.ajax({
        url: '/Exercise/Index',
        type: 'GET',
        data: form_data,
        success: function () {
            location.reload();
        }
    });
});


(function ($) {

    //re-set all client validation given a jQuery selected form or child
    $.fn.resetValidation = function () {

        var $form = this.closest('form');
        alert("3");
        //reset jQuery Validate's internals
        $form.validate().resetForm();

        //reset unobtrusive validation summary, if it exists
        $form.find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();

        //reset unobtrusive field level, if it exists
        $form.find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();

        return $form;
    };

    //reset a form given a jQuery selected form or a child
    //by default validation is also reset
    $.fn.formReset = function (resetValidation) {
        var $form = this.closest('form');

        $form[0].reset();

        if (resetValidation == undefined || resetValidation) {
            $form.resetValidation();
        }

        return $form;
    }
})(jQuery);