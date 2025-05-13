const apiKey = '0978e2504fb80d1dbb02f3e18e711672';
const searchBar = document.querySelector('.search-bar');
const weatherDetails = document.querySelector('.weather-details');
const cityName = document.querySelector('.city-name');
const temperature = document.querySelector('.temperature');
const weatherIcon = document.querySelector('.icon');
const weatherDescription = document.querySelector('.weather-description');
const weatherContainer = document.querySelector('.weather-container');
const hourlyForecastContainer = document.querySelector('.hourly-forecast');
const addFavoriteButton = document.querySelector('.add-favorite');
const favoritesList = document.querySelector('.favorites-list');
const sendButton = document.querySelector('.send-button');
const messageBox = document.querySelector('.message-box');
const notification = document.querySelector('.notification');

const navButtons = document.querySelectorAll('.nav-button');
const homeSection = document.getElementById('home');
const contactSection = document.getElementById('contact');
const humiditySection = document.getElementById('humidity');
const precipitationSection = document.getElementById('precipitation');
const favoritesSection = document.getElementById('favorites');
const aboutSection = document.getElementById('about');

// Navigation logic
navButtons.forEach(button => {
    button.addEventListener('click', () => {
        const target = button.getAttribute('data-target');
        homeSection.style.display = 'none';
        contactSection.style.display = 'none';
        humiditySection.style.display = 'none';
        precipitationSection.style.display = 'none';
        favoritesSection.style.display = 'none';
        aboutSection.style.display = 'none';

        if (target === 'home') homeSection.style.display = 'flex';
        else if (target === 'contact') contactSection.style.display = 'flex';
        else if (target === 'humidity') humiditySection.style.display = 'flex';
        else if (target === 'precipitation') precipitationSection.style.display = 'flex';
        else if (target === 'favorites') {
            favoritesSection.style.display = 'flex';
            renderFavorites(); // Ensure it refreshes list
        }
        else if (target === 'about') aboutSection.style.display = 'flex';
    });
});

// Load stored favorites
let favorites = JSON.parse(localStorage.getItem('favorites')) || [];

searchBar.addEventListener('keypress', (event) => {
    if (event.key === 'Enter') {
        const city = searchBar.value;
        getWeatherData(city);
        getHourlyForecast(city);
    }
});

// Add to favorites logic
addFavoriteButton.addEventListener('click', () => {
    const city = cityName.textContent;
    if (favorites.includes(city)) {
        favorites = favorites.filter(fav => fav !== city);
        addFavoriteButton.textContent = 'Add to Favorites';
    } else {
        if (city && favorites.length < 10) {
            favorites.push(city);
            addFavoriteButton.textContent = 'Remove from Favorites';
        }
    }
    localStorage.setItem('favorites', JSON.stringify(favorites));
    renderFavorites();
});

// Simple message sending
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

// Render the favorites in UI
function renderFavorites() {
    favoritesList.innerHTML = '';
    favorites.forEach(city => {
        const li = document.createElement('li');

        const citySpan = document.createElement('span');
        citySpan.textContent = city;
        citySpan.style.cursor = 'pointer';
        citySpan.style.flex = '1';
        citySpan.style.paddingRight = '10px';
        citySpan.addEventListener('click', () => {
            displayForecastInFavorites(city); // ✅ Updated behavior
        });

        const removeButton = document.createElement('button');
        removeButton.textContent = 'Remove';
        removeButton.addEventListener('click', (event) => {
            event.stopPropagation();
            favorites = favorites.filter(fav => fav !== city);
            localStorage.setItem('favorites', JSON.stringify(favorites));
            renderFavorites();
            if (cityName.textContent === city) {
                addFavoriteButton.textContent = 'Add to Favorites';
            }
        });

        li.style.display = 'flex';
        li.style.justifyContent = 'space-between';
        li.appendChild(citySpan);
        li.appendChild(removeButton);
        favoritesList.appendChild(li);
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

function updateWeatherDetails(data) {
    cityName.textContent = data.name;
    temperature.textContent = `${Math.round(data.main.temp)}°C`;
    weatherIcon.src = `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;
    weatherDescription.textContent = data.weather[0].description;
    weatherDetails.style.display = 'block';
    weatherContainer.classList.add('expanded');

    addFavoriteButton.textContent = favorites.includes(data.name)
        ? 'Remove from Favorites'
        : 'Add to Favorites';
}

function updateHourlyForecast(data) {
    hourlyForecastContainer.innerHTML = '';
    const timezoneOffset = data.city.timezone;
    const forecastList = data.list.slice(0, 9);
    forecastList.forEach(forecast => {
        const forecastElement = document.createElement('div');
        forecastElement.classList.add('forecast-item');
        const localTime = new Date((forecast.dt + timezoneOffset) * 1000).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
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

// ✅ NEW FUNCTION — display weather on Favorites page
function displayForecastInFavorites(city) {
    const forecastContainer = document.getElementById('favorites-forecast');
    const cityDisplay = forecastContainer.querySelector('.city-name');
    const tempDisplay = forecastContainer.querySelector('.temperature');
    const iconDisplay = forecastContainer.querySelector('.icon');
    const descDisplay = forecastContainer.querySelector('.weather-description');
    const hourlyContainer = forecastContainer.querySelector('.hourly-forecast');

    forecastContainer.style.display = 'block';
    cityDisplay.textContent = '';
    tempDisplay.textContent = '';
    iconDisplay.src = '';
    descDisplay.textContent = '';
    hourlyContainer.innerHTML = '';

    getWeatherData(city).then(() => {
        cityDisplay.textContent = cityName.textContent;
        tempDisplay.textContent = temperature.textContent;
        iconDisplay.src = weatherIcon.src;
        descDisplay.textContent = weatherDescription.textContent;
    });

    getHourlyForecast(city).then(() => {
        hourlyContainer.innerHTML = hourlyForecastContainer.innerHTML;
    });
}

// Initial render
renderFavorites();
