namespace GuessThePuppy.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class GameController {
        public puppy;
        public breeds;

        constructor(private $http: ng.IHttpService) {

            $http.get('/api/puppies/random')
                .then((response) => {
                    this.puppy = response.data;
                });
            $http.get('/api/breeds')
                .then((response) => {
                    this.breeds = response.data;
                });

        }
    }
}
