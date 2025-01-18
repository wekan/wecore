import React from 'react';

interface ErrorPageProps {
  error?: Error;
}

export const ErrorPage: React.FC<ErrorPageProps> = ({ error }) => {
  return (
    <div className="error-container">
      <h1>Oops! Something went wrong</h1>
      <p>We're sorry, but we encountered an unexpected error.</p>
      {error && (
        <details className="error-details">
          <summary>Technical Details</summary>
          <pre>{error.message}</pre>
        </details>
      )}
      <button onClick={() => window.location.reload()}>Reload Page</button>
    </div>
  );
};
