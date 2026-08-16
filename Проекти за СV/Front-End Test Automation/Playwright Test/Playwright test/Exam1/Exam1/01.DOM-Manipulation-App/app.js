window.addEventListener("load", solve);

function solve() {
    const numTicketsInput = document.getElementById('num-tickets');
    const seatingPreferenceInput = document.getElementById('seating-preference');
    const fullNameInput = document.getElementById('full-name');
    const emailInput = document.getElementById('email');
    const phoneNumberInput = document.getElementById('phone-number');

    const purchaseBtn = document.getElementById('purchase-btn');
    const editBtn = document.getElementById('edit-btn');
    const buyBtn = document.getElementById('buy-btn');
    const backBtn = document.getElementById('back-btn');

    const ticketPreview = document.getElementById('ticket-preview');
    const purchaseSuccess = document.getElementById('purchase-success');

    const previewNumTickets = document.getElementById('purchase-num-tickets');
    const previewPreference = document.getElementById('purchase-seating-preference');
    const previewFullName = document.getElementById('purchase-full-name');
    const previewEmail = document.getElementById('purchase-email');
    const previewPhoneNumber = document.getElementById('purchase-phone-number');

    let lastPurchaseData = null;

    purchaseBtn.addEventListener('click', onPurchase);
    editBtn.addEventListener('click', onEdit);
    buyBtn.addEventListener('click', onBuy);
    backBtn.addEventListener('click', onBack);

    function onPurchase() {
        const numTickets = numTicketsInput.value.trim();
        const seatingPreference = seatingPreferenceInput.value;
        const fullName = fullNameInput.value.trim();
        const email = emailInput.value.trim();
        const phoneNumber = phoneNumberInput.value.trim();

        if (!numTickets || seatingPreference === 'seating-preference' || !fullName || !email || !phoneNumber) {
            return;
        }

        lastPurchaseData = {
            numTickets,
            seatingPreference,
            fullName,
            email,
            phoneNumber,
        };

        previewNumTickets.textContent = numTickets;
        previewPreference.textContent = seatingPreference;
        previewFullName.textContent = fullName;
        previewEmail.textContent = email;
        previewPhoneNumber.textContent = phoneNumber;

        ticketPreview.style.display = 'block';
        purchaseBtn.disabled = true;
        clearForm();
    }

    function onEdit() {
        if (!lastPurchaseData) {
            return;
        }

        numTicketsInput.value = lastPurchaseData.numTickets;
        seatingPreferenceInput.value = lastPurchaseData.seatingPreference;
        fullNameInput.value = lastPurchaseData.fullName;
        emailInput.value = lastPurchaseData.email;
        phoneNumberInput.value = lastPurchaseData.phoneNumber;

        purchaseBtn.disabled = false;
        ticketPreview.style.display = 'none';
    }

    function onBuy() {
        ticketPreview.style.display = 'none';
        purchaseSuccess.style.display = 'block';
    }

    function onBack() {
        purchaseSuccess.style.display = 'none';
        purchaseBtn.disabled = false;
    }

    function clearForm() {
        numTicketsInput.value = '';
        seatingPreferenceInput.selectedIndex = 0;
        fullNameInput.value = '';
        emailInput.value = '';
        phoneNumberInput.value = '';
    }
}