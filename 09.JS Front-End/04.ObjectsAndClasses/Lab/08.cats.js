function cats(arr) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`)
        }
    }
    
    for(let arg of arr) {
        let [name, age] = arg.split(" ");
        let cat = new Cat(name, age);
        cat.meow(cat);
    }
}

cats(['Mellow 2', 'Tom 5'])