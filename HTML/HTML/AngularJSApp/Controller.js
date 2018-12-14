HtmlApp.controller('htmlCtrl', function ($scope, htmlService) {

    $scope.habilitar = function habilitar() {
        if (document.getElementById('emp_liq').checked) {
            document.getElementById('motivo').removeAttribute("disabled");
        }
        else {
            document.getElementById('onoff').value = ''; //Evita que o usuário defina um texto e desabilite o campo após realiza-lo
            document.getElementById('motivo').setAttribute("disabled", "disabled");
        }
    }


});