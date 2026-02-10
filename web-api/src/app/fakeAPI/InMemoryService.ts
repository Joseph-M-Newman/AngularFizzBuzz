import { InMemoryDbService } from 'angular-in-memory-web-api'

export class InMemoryService implements InMemoryDbService {
    createDb() {
        const numbers = [
            { id: 198, name: "FizzBuzz" },
            { id: 100, name: "FizzBuzz" },
            { id: 5, name: "FizzBuzz" }
        ]
        console.log(numbers);
        return { numbers };
    };
}