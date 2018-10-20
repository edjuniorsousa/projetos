ProdutoApp.service('produtoService', function ($http) {
    //Serviço resposável por listar tds os produtos
    this.getTodosProdutos = function () {
        return $http.get("/Produto/GetProduto");

    }
    //Metodo responsável por Adicionar Funcionario: CREATE
    this.adicionarProduto = function (produto) {
        var request = $http({
            method: 'post',
            url: '/Produto/AdicionarProduto',
            data: produto
        });
        return request;
    }

    //Método responsável por editar produto pelo id: UPDATE
    this.atualizarProduto = function (produto) {
        var request = $http({
            method: 'post',
            url: '/Produto/AtualizarProduto',
            data: produto
        });
        return request;
    }

    //Método responsável por Excluir produto Por Id: Delete
    this.excluirProduto = function (AtualizadoProdutoId) {

        return $http.post('/Produto/Excluirproduto/' + AtualizadoProdutoId);
    }
});