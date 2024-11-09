// Source: https://www.kitesurfy.com/kiteboarding-size-calculator#kite-calculator

function calcolaTagliaKite(pesoRider, velocitaVento, livelloEsperienza, stileNavigazione) {
    const costante = 2.1;
    let tagliaKite = (pesoRider / velocitaVento) * costante;

    // Aumenta o diminuisci la taglia del kite in base allo stile di navigazione
    switch (stileNavigazione) {
        case "Big Air":
            tagliaKite += 1;
            break;
        case "Wavestyle":
            tagliaKite -= 1;
            break;
        // Nessuna modifica per "Freeride" e "Freestyle"
    }

    // Aumenta la taglia del kite di 1 se l'utente è Esperto
    if (livelloEsperienza === "Esperto") {
        tagliaKite += 1;
    }

    // Arrotonda il risultato alla cifra intera più vicina
    return Math.round(tagliaKite);
}

function calcolaEVisualizzaTagliaKite() {
    const pesoRider = document.getElementById('pesoRider').value;
    const velocitaVento = document.getElementById('velocitaVento').value;
    const livelloEsperienza = document.getElementById('livelloEsperienza').value;
    const stileNavigazione = document.getElementById('stileNavigazione').value;

    const tagliaKite = calcolaTagliaKite(pesoRider, velocitaVento, livelloEsperienza, stileNavigazione);
    document.getElementById('risultato').innerText = tagliaKite + " meters";
}