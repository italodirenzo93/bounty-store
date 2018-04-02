<template>
    <div class="container">
        <h1 class="display-3 text-center">New Bounty</h1>
        <bounty-form :bounty="bounty" :errors="errors" @submit="createBounty" @cancel="goBack"></bounty-form>
        <p v-show="success" class="text-success text-center">Your bounty has been posted!</p>
    </div>
</template>

<script>
import axios from 'axios';
import BountyForm from './BountyForm';
import {apiEndpoint} from '../config';

export default {
    components: {
        BountyForm
    },
    data() {
        return {
            bounty: {},
            errors: {},
            success: null
        };
    },
    methods: {
        createBounty(bounty) {
            axios.post(apiEndpoint, bounty)
                .then(() => {
                    // Show success message
                    this.success = true;
                    this.bounty = {};
                    this.errors = {};
                    // Hide it after 4 seconds
                    setTimeout(() => this.success = null, 4000);
                })
                .catch((err) => {
                    // Show error message
                    this.success = false;
                    this.errors = err.response.data;
                });
        },
        goBack() {
            this.$router.push({name: 'bounties'});
        }
    }
};
</script>