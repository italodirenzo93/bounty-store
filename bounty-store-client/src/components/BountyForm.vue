<template>
    <form @submit.prevent="onSubmit">
        <div class="form-group">
            <label for="bountyName">Name:</label>
            <input v-model="bounty.name" required class="form-control" type="text" name="bountyName" />
        </div>
        <div class="form-group">
            <label for="aliveReward">Alive Reward:</label>
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">$</span>
                </div>
                <input v-model="bounty.aliveReward" required class="form-control" type="number" step="0.1" name="aliveReward" />
            </div>
        </div>
        <div class="form-group">
            <label for="deadReward">Dead Reward:</label>
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">$</span>
                </div>
                <input v-model="bounty.deadReward" required class="form-control" type="number" step="0.1" name="deadReward" />
            </div>
        </div>
        <div class="form-group">
            <label for="bountyDescription">Description:</label>
            <textarea v-model="bounty.description" required class="form-control" name="bountyDescription"></textarea>
        </div>
        <div class="form-group">
            <label for="isCaptured">Is Closed?</label>
            <input v-model="bounty.captured" type="checkbox" />
        </div>
        <div class="form-group text-center">
            <button v-if="newBounty" type="submit" class="btn btn-success">Create</button>
            <button v-else type="submit" class="btn btn-success">Update</button>
            <button type="button" class="btn btn-secondary" @click="onCancel">Cancel</button>
        </div>
    </form>
</template>

<script>
export default {
    props: {
        bounty: {
            type: Object,
            required: true
        }
    },
    computed: {
        newBounty() {
            return !(this.bounty.id && this.bounty.id != 0);
        }
    },
    methods: {
        onSubmit() {
            this.$emit('submit', this.bounty);
        },
        onCancel() {
            this.$emit('cancel', this.bounty);
        }
    }
};
</script>