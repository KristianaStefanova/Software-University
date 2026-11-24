function calculateGladiatorExpenses(lostFightsCount, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let totalExpenses = 0;
    let helmetBreaks = 0;
    let swordBreaks = 0;
    let shieldBreaks = 0;
    let armorBreaks = 0;

    for (let i = 1; i <= lostFightsCount; i++) {
        if (i % 2 === 0) {
            helmetBreaks++;
        }

        if (i % 3 === 0) {
            swordBreaks++;
        }

        if (i % 6 === 0) {
            shieldBreaks++;
        }

        if (i % 12 === 0) {
            armorBreaks++;
        }

    }

    totalExpenses = helmetBreaks * helmetPrice + swordBreaks * swordPrice + shieldBreaks * shieldPrice + armorBreaks * armorPrice;
    console.log(`Gladiator expenses: ${totalExpenses.toFixed(2)} aureus`);
}

calculateGladiatorExpenses(7, 2, 3, 4, 5); // returns 16.00