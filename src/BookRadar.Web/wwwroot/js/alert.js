window.Alerts = (() => {
    const toast = Swal.mixin({
        toast: true,
        position: "top-end",
        showConfirmButton: false,
        timer: 3500,
        timerProgressBar: true
    });

    const htmlList = (items) => {
        if (!items || !items.length) return "";
        const li = items.map(x => `<li>${x}</li>`).join("");
        return `<ul style="text-align:left;margin:0 0 0 1rem;">${li}</ul>`;
    };

    return {
        success: (message, title = "Operación exitosa") =>
            Swal.fire({ icon: "success", title, text: message }),

        info: (message, title = "Información") =>
            Swal.fire({ icon: "info", title, text: message }),

        warning: (message, title = "Atención") =>
            Swal.fire({ icon: "warning", title, text: message }),

        error: (message, title = "Ocurrió un error") =>
            Swal.fire({ icon: "error", title, text: message }),

        validation: (errors, title = "Revisa los campos") =>
            Swal.fire({ icon: "error", title, html: htmlList(errors) || "Hay errores de validación." }),

        toastSuccess: (message) => toast.fire({ icon: "success", title: message }),
        toastError: (message) => toast.fire({ icon: "error", title: message })
    };
})();
