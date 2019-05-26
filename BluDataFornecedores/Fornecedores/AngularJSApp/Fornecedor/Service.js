FornecedorApp.service('fornecedorService', function ($http) {
    //Serviço resposável por listar tds os fornecedores
    this.getTodosFornecedores = function () {
        return $http.get("/Fornecedor/GetFornecedor");

    }
    //Serviço resposável por listar tds as empresas
    this.getTodasEmpresas = function () {
        return $http.get("/Empresa/GetEmpresa");
    }

    //Serviço resposável por listar tds as ufs
    this.getTodasUfs = function () {
        return $http.get("/Uf/GetUf");
    }

    //Metodo responsável por cadastrar empresa: CREATE
    this.cadastrarEmpresa = function (empresa) {
        var request = $http({
            method: 'post',
            url: '/Empresa/CadastrarEmpresa',
            data: empresa
        });
        return request;
    }

    //Método responsável por editar empresa pelo id: UPDATE
    this.atualizarEmpresa = function (empresa) {
        var request = $http({
            method: 'post',
            url: '/Empresa/EditarEmpresa',
            data: empresa
        });
        return request;
    }

    //Metodo responsável por cadastrar fornecedor: CREATE
    this.cadastrarFornecedor = function (fornecedor) {
        var request = $http({
            method: 'post',
            url: '/Fornecedor/CadastrarFornecedor',
            data: fornecedor
        });
        return request;
    }
    
});