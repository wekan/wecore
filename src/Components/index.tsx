// ...existing code...

window.addEventListener('unhandledrejection', (event) => {
  console.error('Unhandled Promise Rejection:', event.reason);
  event.preventDefault();
});

window.addEventListener('error', (event) => {
  console.error('Global Error:', event.error);
  event.preventDefault();
});

// ...existing code...
