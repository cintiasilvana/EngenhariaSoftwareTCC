$(document).ready(function () {

    // if form elements page
    if ($('body').hasClass('forms-elements')) {

        //*******************************************
		/*	MASKED  INPUT
		/********************************************/

        $('.phone').mask('(999) 99999-9999');
        $('.phone-fixo').mask('(999) 9999-9999');
        $('.cep').mask('99999-999');
        $('.cnpj').mask('99.999.999/9999-99');
        $('.cpf').mask('999.999.999-99');


        $('.timepicker').timepicker({
            showSeconds: true,
            showMeridian: false,
            defaultTime: false
        });

    } // end ready function
});