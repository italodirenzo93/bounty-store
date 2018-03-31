<template>
    <div class="container">
        <h1 class="display-4 text-center">New Bounty</h1>
        <bounty-form :bounty="bounty" @submit="createBounty" @cancel="goBack"></bounty-form>
        <div v-show="success != null" class="text-center">
            <p v-show="success == true" class="text-success">Your bounty has been posted!</p>
            <p v-show="success == false" class="text-danger">Unable to post bounty.</p>
        </div>
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
            success: null,
            bounty: {}
        };
    },
    methods: {
        createBounty(bounty) {
            axios.post(apiEndpoint, bounty)
                .then(() => {
                    // Show success message
                    this.success = true;
                    this.bounty = {};
                    // Hide it after 4 seconds
                    setTimeout(() => this.success = null, 4000);
                })
                .catch(() => {
                    // Show error message
                    this.success = false;
                });
        },
        goBack() {
            this.$router.push({name: 'bounties'});
        }
    }
};
</script>