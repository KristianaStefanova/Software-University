function login(args) {
    let username = args[0];
    let correctPassword = username.split("").reverse().join("");
    let passwordsArray = args.slice(1);
    let counter = 0;

    while (counter < 4) {
        if (passwordsArray[counter] === correctPassword) {
            console.log(`User ${username} logged in.`);
            return;
        } else {
            if (counter === 3) {
                break;
            }
            console.log("Incorrect password. Try again.");
        }
        counter++;
    }

    console.log(`User ${username} blocked!`);
}

login(['Acer', 'login', 'go', 'let me in', 'recA']);
