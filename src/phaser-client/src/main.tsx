import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import { AppSettingsContextProvider } from "./common/contexts/AppSettingsContext.tsx";
import { PokeGameCoreHttpClientContextProvider } from "./common/contexts/PokeGameCoreHttpClientContext.tsx";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

ReactDOM.createRoot(document.getElementById("root")!).render(
    <React.StrictMode>
        <AppSettingsContextProvider>
            <PokeGameCoreHttpClientContextProvider>
                <QueryClientProvider client={new QueryClient()}>
                    <App />
                </QueryClientProvider>
            </PokeGameCoreHttpClientContextProvider>
        </AppSettingsContextProvider>
    </React.StrictMode>
);
