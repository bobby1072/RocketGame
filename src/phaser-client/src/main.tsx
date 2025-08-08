import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import { AppSettingsContextProvider } from "./common/contexts/AppSettingsContext.tsx";
import { PokeGameCoreHttpClientContextProvider } from "./common/contexts/PokeGameCoreHttpClientContext.tsx";

ReactDOM.createRoot(document.getElementById("root")!).render(
    <React.StrictMode>
        <AppSettingsContextProvider>
            <PokeGameCoreHttpClientContextProvider>
                <App />
            </PokeGameCoreHttpClientContextProvider>
        </AppSettingsContextProvider>
    </React.StrictMode>
);
