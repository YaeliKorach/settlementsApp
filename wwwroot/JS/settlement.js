function createSettlement() {
    const newSettlementName = document.getElementById("newSettlementName").value;


    const newSettlement = {
        name: newSettlementName

    };
    fetch('https://localhost:7293/api/Settlement', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newSettlement),
    })
        .then(response => response.json())
        .then(createdSettlement => {
            console.log('Settlement created:', createdSettlement);
            window.location.href = 'home.html';
        })
        .catch(error => {
            console.error('Error creating settlement:', error);
        });
}
function updateSettlement() {
    const updateSettlementId = new URLSearchParams(window.location.search).get('id');
    const updateSettlementName = document.getElementById("updateSettlementName").value;

    const updatedSettlement = {
        Id: updateSettlementId,
        Name: updateSettlementName
    };

    fetch(`https://localhost:7293/api/Settlement/${updateSettlementId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedSettlement),
    })
        .then(response => response.json())
        .then(updatedSettlement => {
            console.log('Settlement updated:', updatedSettlement);
            window.location.href = 'home.html';
        })
        .catch(error => {
            console.error('Error updating settlement:', error);
        });
}