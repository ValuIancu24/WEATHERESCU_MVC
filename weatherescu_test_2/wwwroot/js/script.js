// Weather app functionality
document.addEventListener('DOMContentLoaded', function () {
    const apiKey = '0978e2504fb80d1dbb02f3e18e711672';

    // Elements for the home page
    const searchBar = document.querySelector('.search-bar');
    const searchButton = document.querySelector('.search-button');
    const weatherDetails = document.querySelector('.weather-details');
    const cityName = document.querySelector('.city-name');
    const temperature = document.querySelector('.temperature');
    const weatherIcon = document.querySelector('.icon');
    const weatherDescription = document.querySelector('.weather-description');
    const hourlyForecastContainer = document.querySelector('.hourly-forecast');

    // Initialize search functionality
    if (searchBar && searchButton) {
        searchButton.addEventListener('click', function () {
            const city = searchBar.value.trim();
            if (city) {
                getWeatherData(city);
                getHourlyForecast(city);
            }
        });

        searchBar.addEventListener('keypress', function (event) {
            if (event.key === 'Enter') {
                const city = searchBar.value.trim();
                if (city) {
                    getWeatherData(city);
                    getHourlyForecast(city);
                }
            }
        });
    }

    // Fetch weather data
    async function getWeatherData(city) {
        const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric`;
        try {
            const response = await fetch(url);
            const data = await response.json();
            updateWeatherDetails(data);
        } catch (error) {
            console.error('Error fetching weather data:', error);
        }
    }

    // Fetch forecast data
    async function getHourlyForecast(city) {
        const url = `https://api.openweathermap.org/data/2.5/forecast?q=${city}&appid=${apiKey}&units=metric`;
        try {
            const response = await fetch(url);
            const data = await response.json();
            updateHourlyForecast(data);
        } catch (error) {
            console.error('Error fetching hourly forecast:', error);
        }
    }

    // Update weather display
    function updateWeatherDetails(data) {
        if (!weatherDetails) return;

        cityName.textContent = data.name;
        temperature.textContent = `${Math.round(data.main.temp)}°C`;
        weatherIcon.src = `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;
        weatherDescription.textContent = data.weather[0].description;
        weatherDetails.style.display = 'block';

        if (weatherContainer) {
            weatherContainer.classList.add('expanded');
        }
    }

    // Update hourly forecast display
    function updateHourlyForecast(data) {
        if (!hourlyForecastContainer) return;

        hourlyForecastContainer.innerHTML = '';
        const timezoneOffset = data.city.timezone;
        const forecastList = data.list.slice(0, 8);

        forecastList.forEach(forecast => {
            const forecastElement = document.createElement('div');
            forecastElement.classList.add('forecast-item');

            const localTime = new Date((forecast.dt + timezoneOffset) * 1000)
                .toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
            const temp = `${Math.round(forecast.main.temp)}°C`;
            const icon = `http://openweathermap.org/img/wn/${forecast.weather[0].icon}.png`;
            const description = forecast.weather[0].description;

            forecastElement.innerHTML = `
                <p>${localTime}</p>
                <img src="${icon}" alt="Weather Icon">
                <p>${temp}</p>
                <p>${description}</p>
            `;

            hourlyForecastContainer.appendChild(forecastElement);
        });
    }

    // Simple message sending (for contact form if you have one)
    const sendButton = document.querySelector('.send-button');
    const messageBox = document.querySelector('.message-box');
    const notification = document.querySelector('.notification');

    if (sendButton && messageBox && notification) {
        sendButton.addEventListener('click', () => {
            const message = messageBox.value;
            if (message.trim() !== '') {
                messageBox.value = '';
                notification.style.display = 'block';
                notification.style.opacity = '1';
                setTimeout(() => {
                    notification.style.opacity = '0';
                    setTimeout(() => {
                        notification.style.display = 'none';
                    }, 1000);
                }, 2000);
            }
        });
    }
});