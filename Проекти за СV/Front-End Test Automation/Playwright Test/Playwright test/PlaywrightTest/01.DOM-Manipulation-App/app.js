window.addEventListener("load", solve);

function solve() {
    const customerNameInput = document.getElementById("customer-name");
    const baseChoiceSelect = document.getElementById("base-choice");
    const fruitChoiceSelect = document.getElementById("fruit-choice");
    const sweetenerAmountInput = document.getElementById("sweetener-amount");

    const orderBtn = document.getElementById("order-btn");
    const editBtn = document.getElementById("edit-btn");
    const confirmBtn = document.getElementById("confirm-btn");
    const backBtn = document.getElementById("back-btn");

    const orderPreview = document.getElementById("order-preview");
    const orderSuccess = document.getElementById("order-success");
    const previewName = document.getElementById("preview-name");
    const previewBase = document.getElementById("preview-base");
    const previewFruit = document.getElementById("preview-fruit");
    const previewSweetener = document.getElementById("preview-sweetener");

    let currentOrder = {
        name: "",
        base: "",
        fruit: "",
        sweetener: ""
    };

    orderBtn.addEventListener("click", onCustomize);
    editBtn.addEventListener("click", onEdit);
    confirmBtn.addEventListener("click", onConfirm);
    backBtn.addEventListener("click", onBack);

    function onCustomize() {
        const name = customerNameInput.value.trim();
        const base = baseChoiceSelect.value;
        const fruit = fruitChoiceSelect.value;
        const sweetener = sweetenerAmountInput.value.trim();

        if (!name || !base || !fruit || !sweetener) {
            return;
        }

        currentOrder.name = name;
        currentOrder.base = base;
        currentOrder.fruit = fruit;
        currentOrder.sweetener = sweetener;

        previewName.textContent = currentOrder.name;
        previewBase.textContent = currentOrder.base;
        previewFruit.textContent = currentOrder.fruit;
        previewSweetener.textContent = currentOrder.sweetener;

        orderPreview.style.display = "block";
        orderBtn.disabled = true;

        customerNameInput.value = "";
        baseChoiceSelect.value = "";
        fruitChoiceSelect.value = "";
        sweetenerAmountInput.value = "";
    }

    function onEdit() {
        customerNameInput.value = currentOrder.name;
        baseChoiceSelect.value = currentOrder.base;
        fruitChoiceSelect.value = currentOrder.fruit;
        sweetenerAmountInput.value = currentOrder.sweetener;

        orderBtn.disabled = false;
        orderPreview.style.display = "none";
    }

    function onConfirm() {
        orderPreview.style.display = "none";
        orderSuccess.style.display = "block";
    }

    function onBack() {
        orderSuccess.style.display = "none";
        orderBtn.disabled = false;
    }
}
  