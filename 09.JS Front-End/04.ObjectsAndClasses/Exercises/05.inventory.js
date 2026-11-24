function inventory(data) {
    class HeroRegister {
        constructor() {
            this.heroesRegister = [];
        }

        _sortList() {
            this.heroesRegister.sort((a, b) => a.level - b.level);
        }

        addHero(hero) {
            this.heroesRegister.push(hero);
            this._sortList();
        }

        print() {
            this.heroesRegister.forEach(hero => {
                console.log(`Hero: ${hero.name}`)
                console.log(`level => ${hero.level}`)
                console.log(`items => ${hero.items.join(", ")}`)
            });
        }
    }

    class Hero {
        constructor(name, level, items) {
            this.name = name,
                this.level = level,
                this.items = items
        }

        set level(level) {
            this._level = Number(level);
        }

        get level() {
            return this._level
        }
    }

    let myRegister = new HeroRegister();
    for (let el of data) {
        let [name, level, itemsStr] = el.split(" / ");
        const items = itemsStr.split(", ")
        const hero = new Hero(name, level, items);
        myRegister.addHero(hero);
    }

    myRegister.print();
}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BdataelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);