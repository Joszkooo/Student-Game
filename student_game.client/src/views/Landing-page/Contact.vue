<template>
    <div class="min-h-screen text-slate-200">
        <div class="container mx-auto p-6">
            <!-- Heading -->
            <div class="text-center mb-12">
                <h1 class="text-5xl font-bold bg-gradient-to-r from-orange-200 via-amber-300 to-amber-400 bg-clip-text text-transparent mb-4">Get in Touch</h1>
                <p class="text-lg text-gray-300">
                    Masz pytania albo feedback? <br>
                    Wpadłeś na ciekawy projekt do wykonania? <br>
                    Pisz śmiało!
                </p>
            </div>
    
            <!-- Content Grid -->
            <div class="grid grid-cols-1 md:grid-cols-2 gap-12">
                <!-- Contact Information -->
                <div class="flex flex-col gap-8">
                    <div class="flex items-center gap-4">
                        <div class="p-4 rounded-full bg-yellow-400 text-gray-900">
                            <i class="fas fa-phone-alt"></i>
                        </div>
                        <div>
                            <h3 class="text-xl font-semibold">Telefon</h3>
                            <p class="text-gray-300">+692143553</p>
                        </div>
                    </div>
                    <div class="flex items-center gap-4">
                        <div class="p-4 rounded-full bg-yellow-400 text-gray-900">
                            <i class="fas fa-envelope"></i>
                        </div>
                        <div>
                            <h3 class="text-xl font-semibold">Email</h3>
                            <p class="text-gray-300">michaljodko02@gmail.com</p>
                        </div>
                    </div>
                </div>
        
                <!-- Contact Form -->
                <!-- CREDIT TO: https://uiverse.io/omriluz/slimy-mole-59 -->
                <div class="form-container" >
                    <H1>NIE DZIALA</H1>
                    <form class="form" @submit.prevent="submitForm">
                        <div class="form-group">
                            <label for="name">Imie</label>
                            <input required name="name" v-model="name" id="name" type="text">

                            <label for="email">Email</label>
                            <input required name="email" v-model="email" id="email" type="email">

                            <!-- <label for="phone">Numer telefonu</label>
                            <input name="phone" id="phone" type="number"> -->
                        </div>
                        <div class="form-group">
                            <label for="message">Wiadomość</label>
                            <textarea required cols="50" rows="10" id="message" name="message" v-model="message"></textarea>
                        </div>
                        
                        <input type="hidden" name="redirect" value="https://web3forms.com/success">
                        <button type="submit" class="form-submit-btn">Wyślij!</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
const WEB3FORMS_ACCESS_KEY = "1606d8fa-e31f-44f2-b84d-f238f4c03057";
const name = ref("")
const email = ref("")
// const phone = ref("")
const message = ref("")

const submitForm = async () => {
    const response = await fetch("https://api.web3forms.com/submit", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        body: JSON.stringify({
            access_key: WEB3FORMS_ACCESS_KEY,
            name: name.value,
            email: email.value,
            message: message.value,
        }),
    });
    const result = await response.json();
    if (result.success) {
        console.log(result);
    }
}
</script>

<style scoped>
    /* Font Awesome CDN (if needed) */
    @import url("https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css");
.form-container {
    width: 500px;
    background: linear-gradient(#282828, #2a2a2a) padding-box,
                linear-gradient(145deg, transparent 35%,#e81cff, #40c9ff) border-box;
    border: 2px solid transparent;
    padding: 32px 24px;
    font-size: 14px;
    font-family: inherit;
    color: white;
    display: flex;
    flex-direction: column;
    gap: 20px;
    box-sizing: border-box;
    border-radius: 16px;
    background-size: 200% 100%;
    animation: gradient 5s ease infinite;
}

@keyframes gradient {
    0% {
        background-position: 0% 50%;
    }

    50% {
        background-position: 100% 50%;
    }

    100% {
        background-position: 0% 50%;
    }
}

.form-container button:active {
    scale: 0.95;
}

.form-container .form {
    display: flex;
    flex-direction: column;
    gap: 20px;
}

.form-container .form-group {
    display: flex;
    flex-direction: column;
    gap: 2px;
}

.form-container .form-group label {
    display: block;
    margin-bottom: 5px;
    color: #717171;
    font-weight: 600;
    font-size: 12px;
}

.form-container .form-group input {
    width: 100%;
    padding: 12px 16px;
    border-radius: 8px;
    color: #fff;
    font-family: inherit;
    background-color: transparent;
    border: 1px solid #414141;
}

.form-container .form-group textarea {
    width: 100%;
    padding: 12px 16px;
    border-radius: 8px;
    resize: none;
    color: #fff;
    height: 96px;
    border: 1px solid #414141;
    background-color: transparent;
    font-family: inherit;
}

.form-container .form-group input::placeholder {
    opacity: 0.5;
}

.form-container .form-group input:focus {
    outline: none;
    border-color: #e81cff;
}

.form-container .form-group textarea:focus {
    outline: none;
    border-color: #e81cff;
}

.form-container .form-submit-btn {
    display: flex;
    align-items: flex-start;
    justify-content: center;
    align-self: flex-start;
    font-family: inherit;
    color: #717171;
    font-weight: 600;
    width: 40%;
    background: #313131;
    border: 1px solid #414141;
    padding: 12px 16px;
    font-size: inherit;
    gap: 8px;
    margin-top: 8px;
    cursor: pointer;
    border-radius: 6px;
}

.form-container .form-submit-btn:hover {
    background-color: #fff;
    border-color: #fff;
}

</style>
