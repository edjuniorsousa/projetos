RepositorioApp.controller('repositorioCtrl', function ($scope, repositorioService) {

    carregarRepositoriosFavoritos();

    carregarRepositorios();
    
   

    var dt = "";

    function carregarRepositorios() {
        var listarRepositorios = repositorioService.getTodosRepositorios();

        listarRepositorios.then(function (d) {

            //se der tudo certo
            $scope.Repositorios = d.data;


        },
            function () {
                alert("Aguarde as bases concluirem os carregamentos!!")


            });
    }
    function carregarRepositoriosFavoritos() {
        var listarRepositoriosFavoritos = repositorioService.getRepositoriosFavoritos();

        listarRepositoriosFavoritos.then(function (d) {

            //se der tudo certo
            $scope.RepositoriosFavoritos = d.data;


        },
            function () {
                alert("Aguarde as bases concluirem os carregamentos!!")


            });
    }

    



    //Método responsavel por resgatar os dados do repositorio pelo Id:
    $scope.detalharRepositorioId = function (repositorio) {
        $scope.id = repositorio.id;
        $scope.nome = repositorio.name;
        $scope.descricao = repositorio.description;
        $scope.linguagem = repositorio.language;
        dt = repositorio.updated_at;
        $scope.data = dt.toString().replace("/Date(", "").replace(")/", "");
        $scope.dono = repositorio.full_name;
        $scope.contribuidores = repositorio.contributors_url;

    }
    //Método responsavel por adicionar repositorio favorito
    $scope.adicionarRepositorio = function () {
        var repositorio = {
            id: $scope.id,
            name: $scope.nome,
            description: $scope.descricao,
            language: $scope.linguagem,
            updated_at: $scope.data,
            full_name: $scope.dono,
            contributors_url: $scope.contribuidores
        };

        var adicionarInfos = repositorioService.adicionarRepositorio(repositorio);

        adicionarInfos.then(function (d) {
            if (d.data.success === true) {
                carregarRepositorios();
                alert("Repositorio adicionado aos favoritos com sucesso!");

                
            }
            else { alert("Repositorio não adicionado aos favoritos!"); }
        },
            function () {
                alert("Repositorio já está cadastrado em favoritos!")
            });
    }


   

    //Método responsavel por pesquisar repositorio
    $scope.getPesquisaRepositorio = function () {
        var repositorio = {
            name: $scope.pesquisaRepos
        };

        var listarRepositoriosPesq = repositorioService.getPesquisaRepositorio(repositorio);

        listarRepositoriosPesq.then(function (d) {

            //se der tudo certo
            $scope.RepositoriosPesquisados = d.data;


        },
            function () {
                alert("Ocorreu um erro ao tentar listar todos os repositorios pesquisados!")


            });
    }
});