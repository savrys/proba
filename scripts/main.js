// Основной функционал
document.addEventListener('DOMContentLoaded', function() {
    // Инициализация tooltips
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    const tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Обработка формы дневника
    const diaryForm = document.getElementById('diaryForm');
    if (diaryForm) {
        diaryForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            const date = document.getElementById('entryDate').value;
            const title = document.getElementById('entryTitle').value;
            const description = document.getElementById('entryDescription').value;
            const status = document.getElementById('entryStatus').value;
            
            // Здесь можно добавить логику сохранения записи
            console.log('Новая запись:', { date, title, description, status });
            
            // Очистка формы
            diaryForm.reset();
            
            // Показать уведомление
            alert('Запись успешно добавлена!');
        });
    }

    // Скачивание резюме
    const downloadBtn = document.querySelector('.btn-primary[href*="download"]');
    if (downloadBtn) {
        downloadBtn.addEventListener('click', function(e) {
            e.preventDefault();
            alert('Резюме будет скачано');
            // Здесь можно добавить реальную логику скачивания
        });
    }

    // Анимация при скролле
    const animateOnScroll = function() {
        const elements = document.querySelectorAll('.project-card, .card');
        
        elements.forEach(element => {
            const elementTop = element.getBoundingClientRect().top;
            const elementVisible = 150;
            
            if (elementTop < window.innerHeight - elementVisible) {
                element.style.opacity = "1";
                element.style.transform = "translateY(0)";
            }
        });
    };

    // Инициализация анимации
    window.addEventListener('scroll', animateOnScroll);
    animateOnScroll(); // Первоначальный вызов
});
