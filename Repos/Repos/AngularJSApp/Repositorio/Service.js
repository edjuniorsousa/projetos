RepositorioApp.service('repositorioService', function ($http) {

    //Serviço resposável por listar tds os repositorios
    this.getTodosRepositorios = function () {
        return $http.get("/Repositorio/GetRepositorio");

    }
    //Metodo responsável por Adicionar repositorio favorito: CREATE
    this.adicionarRepositorio = function (repositorio) {
        var request = $http({
            method: 'post',
            url: '/Repositorio/AdicionarRepositorio',
            data: repositorio
        });
        return request;
    }
    //Serviço resposável por listar tds os repositorios favoritos
    this.getRepositoriosFavoritos = function () {
        return $http.get("/Repositorio/GetRepositoriosFavoritos");

    }
    //Serviço resposável por pesquisar repositorios no github
    this.getPesquisaRepositorio = function (repositorio) {
        var request = $http({
            method: 'post',
            url: '/Repositorio/GetPesquisaRepositorio',
            data: repositorio
        });
        return request;

    }

});
