// Валидация форм
document.addEventListener('DOMContentLoaded', function() {
    const contactForm = document.getElementById('contactForm');
    
    if (contactForm) {
        contactForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            const name = document.getElementById('name').value;
            const email = document.getElementById('email').value;
            const message = document.getElementById('message').value;
            
            // Простая валидация
            if (!name  !email  !message) {
                showAlert('Пожалуйста, заполните все обязательные поля.', 'danger');
                return;
            }
            
            if (!isValidEmail(email)) {
                showAlert('Пожалуйста, введите корректный email адрес.', 'danger');
                return;
            }
            
            // Имитация отправки формы
            showAlert('Сообщение успешно отправлено! Я свяжусь с вами в ближайшее время.', 'success');
            contactForm.reset();
        });
    }
    
    function isValidEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }
    
    function showAlert(message, type) {
        const alertDiv = document.createElement('div');
        alertDiv.className = alert alert-${type} alert-dismissible fade show;
        alertDiv.innerHTML = 
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        ;
        
        const form = document.getElementById('contactForm');
        form.parentNode.insertBefore(alertDiv, form);
        
        // Автоматическое скрытие через 5 секунд
        setTimeout(() => {
            if (alertDiv.parentNode) {
                alertDiv.parentNode.removeChild(alertDiv);
            }
        }, 5000);
    }
});
