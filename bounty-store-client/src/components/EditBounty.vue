<template>
    <div class="container">
        <h1 class="display-3 text-center">Edit Bounty</h1>
        <bounty-form :bounty="bounty" :errors="errors" @submit="updateBounty" @cancel="goBack"></bounty-form>
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
            errors: {}
        };
    },
    created() {
        // Fetch the bounty data
        axios.get(apiEndpoint + '/' + this.$route.params.id)
            .then(res => this.bounty = res.data)
            .catch(() => this.success = false);
    },
    methods: {
        updateBounty(bounty) {
            // PUT request to API
            axios.put(apiEndpoint + '/' + this.$route.params.id, bounty)
                .then(() => this.$router.push({name: 'bounties'}))
                .catch((err) => {
                    this.errors = err.response.data;
                });
        },
        goBack() {
            this.$router.push({name: 'bounties'});
        }
    }
};
</script>