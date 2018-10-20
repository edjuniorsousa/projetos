ProdutoApp.controller('produtoCtrl', function ($scope, produtoService) {
    //aqui estamos carregando tds os dados gravados do produto qnd a pagina for carregada
    carregarProdutos();

    function carregarProdutos() {
        var listarProdutos = produtoService.getTodosProdutos();

        listarProdutos.then(function (d) {

            //se der tudo certo
            $scope.Produtos = d.data;


        },
            function () {
                alert("Ocorreu um erro ao tentar listar todos os produtos!")


            });
    }

    //Método responsavel por adicionar cada propriedade de um novo produto
    $scope.adicionarProduto = function () {
        var produto = {
            produtoId: $scope.produtoId,
            descricao: $scope.descricao,
            quantidade: $scope.quantidade,
            dataCadastro: $scope.dataCadastro,
            valor: $scope.valor
        };

        var adicionarInfos = produtoService.adicionarProduto(produto);

        adicionarInfos.then(function (d) {
            if (d.data.success === true) {
                carregarProdutos();
                alert("Produto adicionado com sucesso!");

                $scope.limparDados();
            }
            else { alert("Produto não adicionado!"); }
        },
            function () {
                alert("Erro ocorrido ao tentar adicionar um novo produto!")
            });
    }
    $scope.limparDados = function () {
        $scope.produtoId = '',
            $scope.descricao = '',
            $scope.quantidade = '',
            $scope.dataCadastro = '',
            $scope.valor = '';
    }
    //Método responsavel por editar produto pelo Id:
    $scope.atualizarProdutoPorId = function (produto) {
        $scope.AtualizadoProdutoId = produto.produtoId;
        $scope.AtualizadoDescricao = produto.descricao;
        $scope.AtualizadoQuantidade = produto.quantidade;
        $scope.AtualizadoDataCadastro = produto.dataCadastro;
        $scope.AtualizadoValor = produto.valor;


    }

    //Método responsável por editar dados do produto:
    $scope.atualizarProduto = function () {
        var produto = {
            produtoId: $scope.AtualizadoProdutoId,
            descricao: $scope.AtualizadoDescricao,
            quantidade: $scope.AtualizadoQuantidade,
            dataCadastro: $scope.AtualizadoDataCadastro,
            valor: $scope.AtualizadoValor
        };

        var atualizarInfos = produtoService.atualizarProduto(produto);
        atualizarInfos.then(function (d) {
            if (d.data.success === true) {
                carregarProdutos();

                alert("Produto Atualizado com sucesso!");
                $scope.limparDadosAtualizados();
            }
            else {
                alert("Produto não Atualizado");
            }
        }, function () {
            alert("Ocorreu um erro ao tentar atualizar o prosuto");
        });

    }

    //Método responsavel por Limpar os Dados depois de Atualizar produto:
    $scope.limparDadosAtualizados = function () {
        $scope.AtualizadoProdutoId = '';
        $scope.AtualizadoDescricao = '';
        $scope.AtualizadoQuantidade = '';
        $scope.AtualizadoValor = '';
        $scope.AtualizadoDataCadastro = '';
    }

    //Método responsavel por resgatar os dados do produto pelo Id para exclusão:

    $scope.excluirProdutoPorId = function (produto) {
        $scope.AtualizadoProdutoId = produto.produtoId;
        $scope.AtualizadoDescricao = produto.descricao;
    }

    //Método responsavel por resgatar os dados do produto pelo Id para compra:
    $scope.comprarProdutoPorId = function (produto) {
        $scope.AtualizadoProdutoId = produto.produtoId;
        $scope.AtualizadoDescricao = produto.descricao;
        $scope.AtualizadoValor = produto.valor;
        $scope.AtualizadoQuantidade = produto.quantidade;
        
    }

    //Método responsavel por Limpar os Dados depois de comprar produto:
    $scope.limparDadosCompra = function () {
        $scope.quantidade = '';
    }
    


    //Método responsável por excluir o produto pelo Id:
    $scope.excluirProduto = function (AtualizadoProdutoId) {

        var excluirInfos = produtoService.excluirProduto($scope.AtualizadoProdutoId);
        excluirInfos.then(function (d) {

            if (d.data.success === true) {
                carregarProdutos();

                alert("produto excluído com Sucesso!");
            }
            else {
                alert("produto não excluído!");
            }
        });
    }

});