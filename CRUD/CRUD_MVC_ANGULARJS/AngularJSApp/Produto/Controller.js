ProdutoApp.controller('produtoCtrl', function ($scope, produtoService) {
    //aqui estamos carregando tds os dados gravados do produto qnd a pagina for carregada
    carregarProdutos();


    //variaveis do carrinhos de compras-------------
    $scope.Compras = [];
    $scope.AtualizadoProdutoId = "";
    $scope.AtualizadoDescricao = "";
    $scope.AtualizadoValor = "";
    $scope.AtualizadoQuantidade = "";
    $scope.quantidadeComprada = "";
    console.log($scope.Compras);
    //------------------------------------------------



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
    //Método responsavel por adicionar produto no carrinho de compras

    $scope.adicionarCarrinho = function (AtualizadoProdutoId,
                                         AtualizadoDescricao, 
                                         AtualizadoValor,
                                         AtualizadoQuantidade,
                                         quantidadeComprada) {

        var ValorTotal = (AtualizadoValor * quantidadeComprada)
        if (quantidadeComprada != 0 || quantidadeComprada != "") {
            if (AtualizadoQuantidade >= quantidadeComprada) {
                $scope.Compras.push({
                    'AtualizadoProdutoId': AtualizadoProdutoId,
                    'AtualizadoDescricao': AtualizadoDescricao,
                    'AtualizadoValor': AtualizadoValor,
                    'quantidadeComprada': quantidadeComprada,
                    'ValorTotal': ValorTotal
                });
            }
            else {
                alert("Quantidade comprada maior do que o estoque!");
                $scope.reset();
            }
        }
        $scope.reset();
    }
    $scope.reset = function () {

        $scope.AtualizadoProdutoId = "";
        $scope.AtualizadoDescricao = "";
        $scope.AtualizadoValor = "";
        $scope.AtualizadoQuantidade = "";
        $scope.quantidadeComprada = "";
        ValorTotal = "";

    }

    //metodo adicionar compra
    $scope.adicionarCompra = function () {
        angular.forEach($scope.Compras, function (value, key) {
            var compra = {
                codigo:1,
                idProduto: value.AtualizadoProdutoId,
                quantidade: value.quantidadeComprada,
                dataVenda: new Date(),
                valorTotal: value.ValorTotal
            };
            var adicionarInfos = produtoService.adicionarCompra(compra);

            adicionarInfos.then(function (d) {
                if (d.data.success === true) {
                    carregarProdutos();
                    alert("Compra finalizada com sucesso!");
                    $scope.Compras = "";
                }
                else { alert("Compra não finalizada com sucesso!"); }
            }, function () {
                alert("Erro ocorrido ao tentar finalizar a compra!")
            });
        });        
    }





    //Método responsavel por adicionar produto
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
        $scope.quantidadeComprada = '';
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