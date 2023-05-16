var currentDate = new Date();
var selectedDay = null;

function populateCalendar() {
    var calendarBody = document.getElementById('calendarBody');
    var monthYear = document.getElementById('monthYear');
    calendarBody.innerHTML = '';

    var year = currentDate.getFullYear();
    var month = currentDate.getMonth();
    var daysInMonth = new Date(year, month + 1, 0).getDate();
    var firstDay = new Date(year, month, 1).getDay();

    var currentDay = 1;
    for (var i = 0; i < 6; i++) {
        var row = document.createElement('tr');

        for (var j = 0; j < 7; j++) {
            if (i === 0 && j < firstDay) {
                var cell = document.createElement('td');
                row.appendChild(cell);
            } else if (currentDay > daysInMonth) {
                break;
            } else {
                var cell = document.createElement('td');
                cell.textContent = currentDay;
                cell.addEventListener('click', function () {
                    selectedDay = this.textContent;
                    showEventForm(this);
                });
                row.appendChild(cell);
                currentDay++;
            }
        }

        calendarBody.appendChild(row);

        if (currentDay > daysInMonth) {
            break;
        }
    }

    monthYear.textContent = new Date(year, month).toLocaleString('default', { month: 'long', year: 'numeric' });
}

function prevMonth() {
    currentDate.setMonth(currentDate.getMonth() - 1);
    populateCalendar();
}

function nextMonth() {
    currentDate.setMonth(currentDate.getMonth() + 1);
    populateCalendar();
}

function showEventForm(cell) {
    var eventForm = document.getElementById('eventForm');
    eventForm.style.display = 'block';
    eventForm.style.top = cell.offsetTop + 'px';
    eventForm.style.left = cell.offsetLeft + 'px';
}

function addEvent(event) {
    event.preventDefault();
    var eventInput = document.getElementById('eventInput');
    var eventText = eventInput.value;
    if (eventText.trim() !== '') {
        var eventList = document.createElement('ul');
        eventList.className = 'event-list';
        var eventItem = document.createElement('li');
        eventItem.textContent = eventText;
        eventList.appendChild(eventItem);

        var cell = document.querySelector('td[data-day="' + selectedDay + '"]');
        if (cell) {
            var existingEventList = cell.querySelector('.event-list');
            if (existingEventList) {
                existingEventList.appendChild(eventItem);
            } else {
                cell.appendChild(eventList);
            }
        }

        eventInput.value = '';
        var eventForm = document.getElementById('eventForm');
        eventForm.style.display = 'none';
    }
}

populateCalendar();
