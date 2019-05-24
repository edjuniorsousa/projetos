FornecedorApp.controller('fornecedorCtrl', function ($scope, fornecedorService) {
    //aqui estamos carregando tds os dados gravados qnd a pagina for carregada
    carregarFornecedores();
    carregarEmpresas();
    carregarDropdownUF();

    function carregarDropdownUF() {
        var listaUf = fornecedorService.getTodasUfs();

        listaUf.then(function (d) {

            //se der tudo certo
            $scope.Ufs = d.data;


        },
            function () {
                alert("Ocorreu um erro ao tentar listar todos os fornecedores!")


            });


    }

    function carregarFornecedores() {
        var listarFornecedores = fornecedorService.getTodosFornecedores();

        listarFornecedores.then(function (d) {

            //se der tudo certo
            $scope.Fornecedores = d.data;


        },
            function () {
                alert("Ocorreu um erro ao tentar listar todos os fornecedores!")


            });
    }



    function carregarEmpresas() {
        var listarEmpresas = fornecedorService.getTodasEmpresas();

        listarEmpresas.then(function (d) {

            //se der tudo certo
            $scope.Empresas = d.data;


        },
            function () {
                alert("Ocorreu um erro ao tentar listar todos as empresas!")


            });
    }
    //Método responsavel por cadastrar empresa
    $scope.cadastrarEmpresa = function () {
        var empresa = {
            id: $scope.id,
            nomeFantasia: $scope.nomeFantasia,
            cnpj: $scope.cnpj,
            uf: $scope.uf
        };

            var adicionarInfos = fornecedorService.cadastrarEmpresa(empresa);

            adicionarInfos.then(function (d) {
                if (d.data.success === true) {
                    carregarEmpresas();
                    alert("Empresa cadastrada com sucesso!");

                    $scope.limparDados();
                }
                else { alert("Empresa não cadastrada!"); }
            },
                function () {
                    alert("Erro ocorrido ao tentar cadastrar uma nova empresa!")
                });
        
    }
    $scope.limparDados = function () {
        $scope.id = '',
            $scope.nomeFantasia = '',
            $scope.cnpj = '',
            $scope.uf = '';
    }


});