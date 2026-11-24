function validatePassword(password) {

    let isLengthValid = password.length >= 6 && password.length <= 10;
    let areElementsValid = /^[A-Za-z0-9]+$/.test(password);
    let areDigitsValid = (password.match(/[0-9]/g) || []).length >= 2;

    if (!isLengthValid) {
        console.log("Password must be between 6 and 10 characters");
    }

    if (!areElementsValid) {
        console.log("Password must consist only of letters and digits");
    }

    if (!areDigitsValid) {
        console.log("Password must have at least 2 digits");
    }

    if (isLengthValid && areElementsValid && areDigitsValid) {
        console.log("Password is valid");
    }
}

validatePassword('logIn');
validatePassword('MyPass123');
validatePassword('Pa$s$s');
