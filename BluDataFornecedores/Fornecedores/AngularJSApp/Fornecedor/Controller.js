FornecedorApp.controller('fornecedorCtrl', function ($scope, fornecedorService) {
    //aqui estamos carregando tds os dados gravados qnd a pagina for carregada
    carregarFornecedores();
    carregarEmpresas();
    carregarDropdownUF();
    //Manter campos invisivéis
    $scope.IsVisiblePf = false;
    $scope.IsVisiblePj = false;
    $scope.IsVisible = false;
    var local = [];
    var data = new Date();


    //testando se o formulário é valido
    //if (!$scope.CadastrarNovoFornecedorForm.$valid) {

    //    alert('Por favor, preencha os campos: Nome, Empresa, tipo');
    //}



    //Tratamento para o parametro dataCadastro e dataNasc
    $scope.replaceString = function (data) {
        return data.replace('/Date(', '').replace(')/', '');
    }

    //Mostrar campos de pesquisa
    $scope.MostrarCampos = function (value) {
        $scope.IsVisible = value == "P";
    }

    //Mostrar campos de pessoa física
    $scope.MostrarCamposPF = function (value) {
        $scope.IsVisiblePf = value == "F";
        $scope.IsVisiblePj = false;
    }
    //Mostrar campos de pessoa juridica
    $scope.MostrarCamposPJ = function (value) {
        $scope.IsVisiblePj = value == "J";
        $scope.IsVisiblePf = false;
    }

    //Carregar dropdown UFs
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
    //Carregar lista de fornecedores
    function carregarFornecedores() {
        var listarFornecedores = fornecedorService.getTodosFornecedores();
        

        listarFornecedores.then(function (d) {

            //se der tudo certo
            $scope.Fornecedores = d.data;
            

            angular.forEach($scope.Fornecedores, function (value, key) {
                value.dataCadastro = $filter('date')(value.dataCadastro.replace('/Date(', '').replace(')/', ''), "dd/MM/yyyy hh:mm a");

            });



        },
            function () {
                alert("Ocorreu um erro ao tentar listar todos os fornecedores!")


            });
    }

   




    //Carregar lista de empresa
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
                else {
                    alert("Empresa não cadastrada!");
                    $scope.limparDados();
                }
            },
                function () {
                    alert("Favor verificar se os dados estão corretos!!")
                    $scope.limparDados();
                });
        
    }
    //Limpar dados empresa
    $scope.limparDados = function () {
        $scope.id = '',
            $scope.nomeFantasia = '',
            $scope.cnpj = '',
            $scope.uf = '';
    }

    //Método responsável por editar dados da empresa:
    $scope.atualizarEmpresa = function () {
        var empresa = {
            id: $scope.id,
            nomeFantasia: $scope.nomeFantasia,
            uf: $scope.uf
        };

        var atualizarInfos = fornecedorService.atualizarEmpresa(empresa);
        atualizarInfos.then(function (d) {
            if (d.data.success === true) {
                carregarEmpresas();

                alert("Empresa atualizada com sucesso!");
                $scope.limparDados();
            }
            else {
                alert("Empresa não atualizada");
            }
        }, function () {
            alert("Ocorreu um erro ao tentar atualizar a empresa");
        });

    }
    //Método responsavel por resgatar dados para editar empresa pelo Id:
    $scope.atualizarEmpresaPorId = function (empresa) {
        $scope.id = empresa.id;
        $scope.nomeFantasia = empresa.nomeFantasia;
        $scope.cnpj = empresa.cnpj;
        $scope.uf = empresa.uf;


    }




    //Método responsavel por cadastrar fornecedor
    $scope.cadastrarFornecedor = function () {
        var fornecedor = {
            id: $scope.id,
            nome: $scope.nome,
            cnpjOuCpf: $scope.cpfCnpj,
            idEmpresa: $scope.nomeFantasia,
            tipo: $scope.tipo,
            dataCadastro: new Date(),
            telefone: $scope.telefone,
            rg: $scope.rg,
            dataNasc: $scope.dataNasc

        };
        
        var pessoa = $scope.tipo;
        var ano = data.getFullYear();
        angular.forEach($scope.Empresas, function (value, key) {
            if (value.uf === "PR" & value.id === parseInt($scope.nomeFantasia)) 
                local = value.uf;
            
        });
        


        var adicionarInfos = fornecedorService.cadastrarFornecedor(fornecedor);
        if (pessoa === 'PF') {
            if (ano - $scope.dataNasc.getFullYear() < 18 && local === 'PR') {

                
                alert("Não é permitido cadastrar fornecedor(PF) menor de idade para empresas do estado do PR!");
                local = '';
                carregarFornecedores();
                $scope.limparDadosFornecedor();

            }
            else {

                adicionarInfos.then(function (d) {


                    if (d.data.success === true) {
                        carregarFornecedores();
                        alert("Fornecedor cadastrado com sucesso!");

                        $scope.limparDadosFornecedor();
                    }
                    else {
                        alert("Fornecedor não cadastrado!");
                        $scope.limparDadosFornecedor();
                    }

                },
                    function () {
                        alert("Favor verificar se os dados estão corretos!!")
                        $scope.limparDadosFornecedor();
                    });
            }
        }
        else {
            adicionarInfos.then(function (d) {


                if (d.data.success === true) {
                    carregarFornecedores();
                    alert("Fornecedor cadastrado com sucesso!");

                    $scope.limparDadosFornecedor();
                }
                else {
                    alert("Fornecedor não cadastrado!");
                    $scope.limparDadosFornecedor();
                }

            },
                function () {
                    alert("Favor verificar se os dados estão corretos!!")
                    $scope.limparDadosFornecedor();
                });

        }
    }
    //Limpar dados fornecedor
    $scope.limparDadosFornecedor = function () {
        $scope.id = '',
            $scope.nome = '',
            $scope.cpfCnpj = '',
            $scope.nomeFantasia = '',
            $scope.tipo = '',
            $scope.telefone = '',
            $scope.rg = '',
            $scope.dataNasc = '';
    }

    

    


});





