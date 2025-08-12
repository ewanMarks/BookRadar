(() => {
    const form = document.getElementById("searchForm");
    const btn = document.getElementById("btnSearch");
    const author = document.getElementById("author");

    if (!form || !btn || !author) return;

    author.addEventListener("input", () => {
        if (author.value.trim()) author.classList.remove("is-invalid");
    });

    form.addEventListener("submit", (event) => {
        if (!author.value.trim()) {
            author.classList.add("is-invalid");
            Alerts.error("El autor es obligatorio.", "Validación");
            event.preventDefault();
            return false;
        }
        btn.disabled = true;
        btn.innerHTML = "⏳ <span>Buscando…</span>";
    });
})();
